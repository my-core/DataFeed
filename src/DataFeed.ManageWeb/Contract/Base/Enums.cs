using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataFeed.ManageWeb.Contract.Base
{
    public enum TableTemplateType
    {
        [Description("管理员信息表单")]
        UserForm = 1,
        [Description("文章信息表单")]
        Article = 2
    }

    public enum TableFieldType
    {
        [Description("文本")]
        Text = 1,
        [Description("文本段")]
        TextArea = 2,
        [Description("选择下拉框")]
        Select = 3,
        [Description("单选框")]
        Radio = 4,
        [Description("复选框")]
        CheckBox = 5
    }
}
