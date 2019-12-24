using DataFeed.Geography.FeedMonitor.DataContract;
using DataFeed.Geography.FeedMonitor.Model.Mongo;
using DataFeed.Geography.FeedMonitor.Repository.Mongodb;
using DataFeed.Framework.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataFeed.Framework.Utils;
using System.Threading;
using System.Diagnostics;

namespace DataFeed.Geography.FeedMonitor.Service
{
    public class GeographyService : IGeographyService
    {
        private ILogger<GeographyService> _logger;
        private IGeographyMongoRepository _geographyMongoRepository;
        private IGeographyRepository _geographyRepository;

        /// <summary>
        /// 线程组
        /// </summary>
        private Thread[] countyThreads;
        private Thread[] townThreads;
        private Thread[] villageThreads;
        /// <summary>
        /// 队列
        /// </summary>
        private Stack<List<CountyInfo>> countyQueue = new Stack<List<CountyInfo>>();
        private Stack<List<TownInfo>> townQueue = new Stack<List<TownInfo>>();
        private Stack<List<VillageInfo>> villageQueue = new Stack<List<VillageInfo>>();
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="geographyMongoRepository"></param>
        /// <param name="geographyRepository"></param>
        public GeographyService(ILogger<GeographyService> logger, IGeographyMongoRepository geographyMongoRepository, IGeographyRepository geographyRepository)
        {
            _logger = logger;
            _geographyMongoRepository = geographyMongoRepository;
            _geographyRepository = geographyRepository;

            countyThreads = new Thread[15];
            for (int i = 0; i < 10; i++)
            {
                Thread crawlThread = new Thread(DoWork_County);
                crawlThread.Name = i.ToString();
                crawlThread.Start();
                countyThreads[i] = crawlThread;
            }
            townThreads = new Thread[20];
            for (int i = 0; i < 20; i++)
            {
                Thread crawlThread = new Thread(DoWork_Town);
                crawlThread.Name = i.ToString();
                crawlThread.Start();
                townThreads[i] = crawlThread;
            }
            villageThreads = new Thread[30];
            for (int i = 0; i < 30; i++)
            {
                Thread crawlThread = new Thread(DoWork_Village);
                crawlThread.Name = i.ToString();
                crawlThread.Start();
                villageThreads[i] = crawlThread;
            }
        }

        /// <summary>
        /// 将抓取到数据保存mongodb库
        /// </summary>
        /// <param name="list"></param>
        public void InsertGeography(List<GeographyModel> list)
        {
            _geographyMongoRepository.Insert(list);
        }

        /// <summary>
        /// 处理数据，清洗抓取数据并保存到mysql库
        /// </summary>
        public void HandleGeographyData()
        {
            try
            {
                HandleProvinceData();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "HandleGeographyData");
            }
        }

        /// <summary>
        /// 省
        /// </summary>
        private void HandleProvinceData()
        {
            var result = _geographyMongoRepository.GetProvinceList();
            List<ProvinceInfo> list = new List<ProvinceInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.ProvinceName);
                list.Add(new ProvinceInfo
                {
                    ProvinceCode = item.ProvinceCode,
                    ProvinceName = item.ProvinceName,
                    ShorName = GeoUtils.GetShortName(item.ProvinceName),
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleCityData(item.ProvinceCode);
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 市
        /// </summary>
        private void HandleCityData(string provinceCode)
        {
            List<CityVo> result = _geographyMongoRepository.GetCityList(provinceCode);
            List<CityInfo> list = new List<CityInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.CityName);
                list.Add(new CityInfo
                {
                    ProvinceCode = provinceCode,
                    CityCode = item.CityCode,
                    CityName = item.CityName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleCountyData(item.CityCode);
            });
            if (list.Count > 0)
                _geographyRepository.Insert(list);
        }

        /// <summary>
        /// 区
        /// </summary>
        private void HandleCountyData(string cityCode)
        {
            List<CountyVo> result = _geographyMongoRepository.GetCountyList(cityCode);
            List<CountyInfo> list = new List<CountyInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.CountyName);
                list.Add(new CountyInfo
                {
                    CityCode = cityCode,
                    CountyCode = item.CountyCode,
                    CountyName = item.CountyName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleTownData(item.CountyCode);
            });
            if (list.Count > 0)
                countyQueue.Push(list);
        }

        /// <summary>
        /// 镇
        /// </summary>
        private void HandleTownData(string countyCode)
        {
            List<TownVo> result = _geographyMongoRepository.GetTownList(countyCode);
            List<TownInfo> list = new List<TownInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.TownName);
                list.Add(new TownInfo
                {
                    CountyCode = countyCode,
                    TownCode = item.TownCode,
                    TownName = item.TownName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
                HandleVillageData(item.TownCode);
            });
            if (list.Count > 0)
                townQueue.Push(list);
        }

        /// <summary>
        /// 乡
        /// </summary>
        private void HandleVillageData(string townCode)
        {
            List<VillageVo> result = _geographyMongoRepository.GetVillageList(townCode);
            List<VillageInfo> list = new List<VillageInfo>();
            result.ForEach(item =>
            {
                var spell = GetSpell(item.VillageName);
                list.Add(new VillageInfo
                {
                    TownCode = townCode,
                    VillageCode = item.VillageCode,
                    VillageName = item.VillageName,
                    Spell = spell,
                    FirstLetter = spell[0].ToString()
                });
            });
            if (list.Count > 0)
                villageQueue.Push(list);
                //_geographyRepository.Insert(list);
        }

        /// <summary>
        /// 开始线程
        /// </summary>
        /// <param name="data"></param>
        private void DoWork_Village()
        {
            try
            {
                while (true)
                {                    
                    List<VillageInfo> list = null;
                    lock (villageQueue)
                    {
                        if (villageQueue.Count == 0)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            continue;
                        }
                        list = villageQueue.Pop();
                    }
                    if (list == null)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        continue;
                    }
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    _geographyRepository.Insert(list);
                    stopwatch.Stop();
                    _logger.LogWarning("InsertVillageList->{0}ms", stopwatch.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DoWork failed");
                // 线程被放弃
            }
        }
        /// <summary>
        /// 开始线程
        /// </summary>
        /// <param name="data"></param>
        private void DoWork_Town()
        {
            try
            {
                while (true)
                {
                    List<TownInfo> list = null;
                    lock (townQueue)
                    {
                        if (townQueue.Count == 0)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            continue;
                        }
                        list = townQueue.Pop();
                    }
                    if (list == null)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        continue;
                    }

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    _geographyRepository.Insert(list);
                    stopwatch.Stop();
                    _logger.LogWarning("InsertTownList->{0}ms", stopwatch.ElapsedMilliseconds);
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DoWork failed");
                // 线程被放弃
            }
        }

        /// <summary>
        /// 开始线程
        /// </summary>
        /// <param name="data"></param>
        private void DoWork_County()
        {
            try
            {
                while (true)
                {
                    List<CountyInfo> list = null;
                    lock (countyQueue)
                    {
                        if (countyQueue.Count == 0)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            continue;
                        }
                        list = countyQueue.Pop();
                    }
                    if (list == null)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        continue;
                    }
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    _geographyRepository.Insert(list);
                    stopwatch.Stop();
                    _logger.LogWarning("InsertCountyList->{0}ms", stopwatch.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DoWork failed");
                // 线程被放弃
            }
        }

        /// <summary>
        /// 获取全拼并将首字母大写
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string GetSpell(string text)
        {
            string ret = string.Empty;
            string spell = NPinyin.Pinyin.GetPinyin(text);
            var spellArr = spell.Split(' ').ToList();
            spellArr.ForEach(item =>
            {
                ret += item.Substring(0, 1).ToUpper() + item.Substring(1);
            });
            return ret;
        }
    }
}
