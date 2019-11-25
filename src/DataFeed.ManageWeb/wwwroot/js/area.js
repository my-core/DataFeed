//地区选择事件
var pidObj, cidObj, didObj;
function InitAreaSelect(pid, cid, did) {
    pidObj = $("#" + pid);
    cidObj = $("#" + cid);
    didObj = $("#" + did);
    layui.use(['form'], function () {
        var form = layui.form;
        form.on('select(' + pid + ')', function (data) {
            bindCity(data.value);
        });
        form.on('select(' + cid + ')', function (data) {
            bindDistrict(data.value);
        });
        function bindCity(provinceID) {
            if (provinceID == undefined || provinceID == null)
                return;
            DoAjax('/Content/CityList/' + provinceID, {}, 'POST', function (data) {
                var html = '<option value="">-请选择-</option>';
                if (data.length > 0) {
                    $.each(data, function (index, item) {
                        html += '<option value="' + item.ID + '">' + item.CityName + '</option>';
                    });
                }
                cidObj.html(html);
                form.render();
                bindDistrict();
            });
        }

        function bindDistrict(cityID) {
            if (cityID == undefined || cityID == null)
                return;
            DoAjax('/Content/DistrictList/' + cityID, {}, 'POST', function (data) {
                var html = '<option value="">-请选择-</option>';
                if (data.length > 0) {
                    $.each(data, function (index, item) {
                        html += '<option value="' + item.ID + '">' + item.DistrictName + '</option>';
                    });
                }
                didObj.html(html);
                form.render();
            });
        }
    });

}


 