for /f "tokens=1,2,3 delims=/- " %%a in ("%date%") do @set D=%%c%%a%%b
for /f "tokens=1,2,3 delims=:." %%a in ("%time%") do @set T=%%a%%b%%c
set T=%T: =0%
set currenttime=%D%%T%
set imagetag=newsfeedmonitor:%currenttime%
set dockerserver=docker.isuperx.com
set projectname=superx
set image=%dockerserver%/%projectname%/%imagetag%
docker build --rm -t %imagetag% -f Dockerfile ..
docker tag %imagetag% %image%
docker login -u=guohulin -p=Aa123456 %dockerserver%
docker push %image%
pause