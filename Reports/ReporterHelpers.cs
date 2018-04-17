using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports
{
    internal static class ReporterHelpers
    {
        enum DateTimeTypes
        {
            Date,
            Time,
            DateTime
        }

        static ReporterParameter ReplaceParamTextName(this ReporterParameter param)
        {
            param.Html = param.Html
                .Replace("parameter_name", param.Name)
                .Replace("parameter_text", param.Text);
            param.Js = param.Js
                .Replace("parameter_name", param.Name)
                .Replace("parameter_text", param.Text);
            return param;
        }


        public static ReporterParameter CreateTextBox(this ReporterParameter param, string placeHolder = "")
        {
            param.ValueType = ParameterValueType.String;

            if (placeHolder.isNotNullOrWhiteSpace())
                placeHolder = $"placeholder: '{placeHolder}',";

            param.Html = $@"<div class='option'><span>parameter_text</span><div id='parameter_name'></div></div>";
            param.Js = @"
                <script>$(function() {
                    $('#parameter_name').dxTextBox({
                        valueChangeEvent: 'keyup',
                        "+ placeHolder +@"
                        onValueChanged: function (e) {
                            jQuery.data(document.body, 'parameter_name_value', e.value);
                        }
                    });
                    jQuery.data(document.body, 'parameter_name_value', getTextBox('parameter_name').option('value'));
                    }
                    )
                </script>
                ";
            return param.ReplaceParamTextName();
        }



        #region CrateDate / CreateDateTime / CreateTime
        public static ReporterParameter CreateDate(this ReporterParameter param)
        {
            return param.CreateDateTime(DateTimeTypes.Date, "", false);
        }

        public static ReporterParameter CreateTime(this ReporterParameter param)
        {
            return param.CreateDateTime(DateTimeTypes.Time, "", false);
        }

        public static ReporterParameter CreateDateTime(this ReporterParameter param)
        {
            return param.CreateDateTime(DateTimeTypes.DateTime, "", false);
        }

        static ReporterParameter CreateDateTime(this ReporterParameter param, DateTimeTypes dateTimeType, string displayFormat, bool roller = false)
        {
            param.ValueType = ParameterValueType.DateTime;

            string typeString = "";
            string defDisplayFormat = "";
            switch (dateTimeType)
            {
                default:
                case DateTimeTypes.Date:
                    typeString = "date";
                    defDisplayFormat = "dd.MM.yyyy";
                    break;
                case DateTimeTypes.Time:
                    typeString = "time";
                    defDisplayFormat = "HH:mm";
                    break;
                case DateTimeTypes.DateTime:
                    typeString = "datetime";
                    defDisplayFormat = "dd.MM.yyyy HH:mm";
                    break;
            }
            if (displayFormat.isNullOrWhiteSpace())
                displayFormat = defDisplayFormat;

            param.Html = $@"<div class='option'><span>parameter_text</span><div id='parameter_name'></div></div>";
            param.Js = @"
                <script>$(function() {
                    $('#parameter_name').dxDateBox({
                        type: '"+typeString+@"',
                        displayFormat:'"+displayFormat+@"',
                        value: new Date(),
                        onValueChanged: function (e) {
                            var previousValue = e.previousValue;
                            var newValue = e.value;
                            jQuery.data(document.body, 'parameter_name_value', dateToString(e.value));
                        }
                    });
                    jQuery.data(document.body, 'parameter_name_value', dateToString(getDate('parameter_name').option('value')));
                    }
                    )
                </script>
                ";
            return param.ReplaceParamTextName();
        }
        #endregion

        public static ReporterParameter CreateTeknisyenSelect(this ReporterParameter param, bool multipleSelect)
        {
            param.ValueType = ParameterValueType.TeknisyenSecimi;

            string selectType = (multipleSelect ? "multiple" : "single");

            param.Html = $@"<div class='option'><span>parameter_text</span><div id='parameter_name'></div></div>";
            param.Js = @"
            <script>$(function() {

                var dataGrid = $('#parameter_name').dxDataGrid({
                    //dataSource: sales,
                    selection:
                        {
                            mode: '" + selectType + @"'
                    },
                    paging:
                        {
                            pageSize: 10
                    },
                    filterRow:
                        {
                            visible: true
                    },
                    columns: [
                        {
                            dataField: 'ID', 
                            caption: 'ID',
                            width: 90,
                            visible: false
                        },
                        {
                            dataField:'AdSoyad',
                            caption:'Adi Soyadi',
                            width:200
                        }
                        ],
                    onSelectionChanged: function (selectedItems) {
                                var teknisyenIds = '';
                                $.each(selectedItems.selectedRowKeys, function(index, item) {
                                    teknisyenIds += item.ID + ','; 
                                });
                                jQuery.data(document.body, 'parameter_name_value', teknisyenIds);
                        }
                }).dxDataGrid('instance');

                jQuery.data(document.body, 'parameter_name_value', '');        

                dataGrid.option('selection.selectAllMode', 'allPages');
                dataGrid.option('selection.showCheckBoxesMode', 'onClick');
                    
                action('Teknisyen', 'GetServisTeknisyenListesi', { servisId: jQuery.data(document.body, 'ServisId') }, function (res) {
                    if (res.Ok) {
                       getGrid('parameter_name').option('dataSource', res.Data);    
                    }
                }
                );
 
            }
            )   
            </script>
            ";
            return param.ReplaceParamTextName();
        }

        public static ReporterParameter CreateServislerSelect(this ReporterParameter param, bool multipleSelect)
        {
            string selectType = (multipleSelect ? "multiple" : "single");

            param.Html = $@"<div class='option'><span>parameter_text</span><div id='parameter_name'></div></div>";
            param.Js = @"
            <script>$(function() {

                var dataGrid = $('#parameter_name').dxDataGrid({
                    selection:
                        {
                            mode: '" + selectType + @"'
                    },
                    paging:
                        {
                            pageSize: 12
                    },
                    filterRow:
                        {
                            visible: true
                    },
                    columns: [
                        {
                            dataField: 'ID', 
                            caption: 'ID',
                            width: 90,
                            visible: false
                        },
                        {
                            dataField:'AD',
                            caption:'Servis',
                            width:400
                        }
                        ],
                    onSelectionChanged: function (selectedItems) {
                                var servisIds = '';
                                $.each(selectedItems.selectedRowKeys, function(index, item) {
                                    servisIds += item.ID + ','; 
                                });
                                jQuery.data(document.body, 'parameter_name_value', servisIds);
                        }
                }).dxDataGrid('instance');

                jQuery.data(document.body, 'parameter_name_value', '');        

                dataGrid.option('selection.selectAllMode', 'allPages');
                dataGrid.option('selection.showCheckBoxesMode', 'onClick');

                action('Sason', 'GetManServisListesi', null, function (res) {
                    if (res.Ok) {
                       getGrid('parameter_name').option('dataSource', res.Data);
                    }
                }
                );
 
            }
            )   
            </script>
            ";
            return param.ReplaceParamTextName();
        }


        public static ReporterParameter CreateRecetelerSelect(this ReporterParameter param, bool multipleSelect)
        {
            string selectType = (multipleSelect ? "multiple" : "single");

            param.Html = $@"<div class='option'><span>parameter_text</span><div id='parameter_name'></div></div>";
            param.Js = @"
            <script>$(function() {

                var dataGrid = $('#parameter_name').dxDataGrid({
                    selection:
                        {
                            mode: '" + selectType + @"'
                    },
                    paging:
                        {
                            pageSize: 12
                    },
                    filterRow:
                        {
                            visible: true
                    },
                    columns: [
                        {
                            dataField: 'ID', 
                            caption: 'ID',
                            width: 90,
                            visible: false
                        },
                        {
                            dataField:'KOD',
                            caption:'Recete',
                            width:400
                        }
                        ],
                    onSelectionChanged: function (selectedItems) {
                                var receteIds = '';
                                $.each(selectedItems.selectedRowKeys, function(index, item) {
                                    receteIds += item.ID + ','; 
                                });
                                jQuery.data(document.body, 'parameter_name_value', receteIds);
                        }
                }).dxDataGrid('instance');

                jQuery.data(document.body, 'parameter_name_value', '');        

                dataGrid.option('selection.selectAllMode', 'allPages');
                dataGrid.option('selection.showCheckBoxesMode', 'onClick');

                action('Sason', 'GetReceteListesi', null, function (res) {
                    if (res.Ok) {
                       getGrid('parameter_name').option('dataSource', res.Data);
                    }
                }
                );
 
            }
            )   
            </script>
            ";
            return param.ReplaceParamTextName();
        }

        public static ReporterParameter CreateIsEmirHizmetYeri(this ReporterParameter param, bool multipleSelect)
        {
            string selectType = (multipleSelect ? "multiple" : "single");

            param.Html = $@"<div class='option'><span>parameter_text</span><div id='parameter_name'></div></div>";
            param.Js = @"
            <script>$(function() {

                var dataGrid = $('#parameter_name').dxDataGrid({
                    //dataSource: sales,
                    selection:
                        {
                            mode: '" + selectType + @"'
                    },
                    paging:
                        {
                            pageSize: 12
                    },
                    filterRow:
                        {
                            visible: true
                    },
                    columns: [
                        {
                            dataField: 'ID', 
                            caption: 'ID',
                            width: 90,
                            visible: false
                        },
                        {
                            dataField:'AD',
                            caption:'Servis',
                            width:150
                        }
                        ],
                    onSelectionChanged: function (selectedItems) {
                                var servisIds = '';
                                $.each(selectedItems.selectedRowKeys, function(index, item) {
                                    servisIds += item.ID + ','; 
                                });
                                jQuery.data(document.body, 'parameter_name_value', servisIds);
                        }
                }).dxDataGrid('instance');

                jQuery.data(document.body, 'parameter_name_value', '');

                dataGrid.option('selection.selectAllMode', 'allPages');
                dataGrid.option('selection.showCheckBoxesMode', 'onClick');

                action('Sason', 'GetIsEmirHizmetYerleri', null, function (res) {
                    if (res.Ok) {
                       getGrid('parameter_name').option('dataSource', res.Data);
                    }
                }
                );
 
            }
            )   
            </script>
            ";
            return param.ReplaceParamTextName();
        }
    }
}