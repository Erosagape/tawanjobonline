//basic function tools for binding
function SetListOfValues(ev) {
    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2').done(ev);
}
function CheckSession(ev) {
    $.get(path + 'Config/GetLogin', function (r) {
        if (r.user.data.UserID == null) {
            $('#cboDatabase').empty();
            $('#cboDatabase').append($('<option>', { value: '' })
                .text('N/A'));
            $.get(path + 'Config/GetDatabase').done(function (dr) {
                if (dr.database.length > 0) {
                    for (let i = 0; i < dr.database.length; i++) {
                        $('#cboDatabase').append($('<option>', { value: (i + 1) })
                            .text(dr.company + '->' + dr.database[i].trim()));
                    }
                    $('#cboDatabase').val(1);                    
                    $('#dvLogin').modal('show');
                }
            });
        } else {
            try {
                if (ev !== null) {
                    ev();
                }
            } catch {

            }
        }
    });
}
function CheckPassword(db, user, ev) {
    bootbox.prompt({
        title: mainLanguage == "TH" ? "กรุณาใส่รหัสผ่าน" : "Please enter your password",
        inputType: 'password',
        buttons: {
            cancel: {
                label: mainLanguage == "TH" ? 'ยกเลิก' : 'Cancel',
                className: 'btn-danger'
            },
            confirm: {
                label: mainLanguage == "TH" ? 'ยืนยัน' :'Confirm',
                className: 'btn-success'                
            }
        },
        callback: function (pass) {
            if (pass !== null) {
                $.get(path + 'Config/SetLogin?Database=' + db + '&Code=' + user + '&Pass=' + pass, function (r) {
                    if (r.user.data.length > 0) {
                        ev();
                    } else {
                        ShowMessage(r.user.message,true);
                    }
                });
            }
        }
    });
}
function ShowMessage(str, iserr = false) {
    try
    {
        if (iserr) {
            let box = bootbox.alert({
                title: mainLanguage=='TH'? '<b>พบข้อผิดพลาด</b>': '<b>Error</b>' ,
                message: '<i class="glyphicon glyphicon-remove-sign" style="font-size:30px;color:red;padding-right:10px"></i>'+ GetLanguage(str)
            });
            box.find('.modal-header').css({ 'background-color': 'red','color':'white' });
            box.find('.modal-footer').css({ 'background-color': 'lightyellow' });
            box.find(".btn-primary").removeClass("btn-primary").addClass("btn-danger");
        } else {
            let box =bootbox.alert({
                title: mainLanguage=='TH' ?'<b>ข้อความจากระบบ</b>': '<b>Information</b>' ,
                message: '<i class="glyphicon glyphicon-exclamation-sign" style="font-size:30px;color:blue;padding-right:10px"></i>'+ GetLanguage(str)
            });
            box.find('.modal-header').css({ 'background-color': 'green', 'color': 'white' });
            box.find('.modal-footer').css({ 'background-color': 'lightyellow' });
            box.find(".btn-primary").removeClass("btn-primary").addClass("btn-success");
        }
    }
    catch
    {
        alert(str);
    }
}
function ShowConfirm(str,func) {
    //bootbox.confirm(str, func);
    let box=bootbox.confirm({
        title: mainLanguage == "TH" ? "<b>กรุณายืนยัน<b/>" : "<b>confirm</b>",
        message: '<span class="glyphicon glyphicon-question-sign" style="font-size:30px;color:blue;padding-right:10px"></span>' + GetLanguage(str),
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> ' + (mainLanguage == "TH" ? 'ยกเลิก' :'Cancel')
            },
            confirm: {
                label: '<i class="fa fa-check"></i> ' + (mainLanguage == "TH" ? 'ยืนยัน' : 'Confirm')
            }
        },
        callback: func
    });
    box.find('.modal-header').css({ 'background-color': 'red', 'color': 'yellow' });
    box.find('.modal-footer').css({ 'background-color': 'lightyellow' });
    box.find(".btn-primary").removeClass("btn-primary").addClass("btn-success");
    box.find(".btn-secondary").removeClass("btn-secondary").addClass("btn-warning");
}
function CreateLOV(dv, frm, tb, name, html, c) {
    if (c <= 4) html = html.replace('<th>desc2</th>', '');
    if (c <= 3) html = html.replace('<th>desc1</th>', '');
    if (c <= 2) html = html.replace('<th>name</th>', '');
    if (c == 1) html = html.replace('<th>key</th>', '');

    let lov = document.createElement("div");
    lov.className = "modal fade";
    lov.setAttribute("role", "dialog");
    lov.id = frm.replace("#", "");
    dv.appendChild(lov);

    let struct = html.replace('tbX', tb.replace("#", "")).replace('cpX', name);
    BindList(frm, tb, struct);
}
function BindList(d, t, l) {
    //use for set html of tables and set focus when showing
    $(d).html(l);
    $(d).on('shown.bs.modal', function () {
        $(t + '_filter input').focus();
    });
}
function BindEvent(t, d, ev) {
    //use for bind event of popup when click some row and selected data
    $(t + ' tbody').on('click', 'button', function () {
        let dt = GetSelect(t, this); //read current row selected
        ev(dt); //callback function from caller 
        $(d).modal('hide');
    });
    $(t + ' tbody').on('click', 'tr', function () {
        $(t + ' tbody > tr').removeClass('selected'); //ล้างทุก row ที่มีการ select ก่อน
        $(this).addClass('selected'); //select row ใหม่
    });
    $(d).modal('show');
}
function ShowWait() {
    if ($('#dvWaiting').is(':visible')) {
        return;
    }
    $('#dvWaiting').modal('show');
}
function CloseWait() {
    $('#dvWaiting').modal('hide');  
}
//Function for loading data to Grid for popup selection
function SetGridConfigList(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Config/GetList', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'config.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "ConfigCode", title: "Setting" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true, pageLength: 25 //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridConfigVal(p, g, t, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Config/GetConfig?Prefix=' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'config.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "ConfigCode", title: mainLanguage == "TH" ? "กลุ่ม" : "Code" },
            { data: "ConfigKey", title: mainLanguage == "TH" ? "รหัส" : "Key" },
            { data: "ConfigValue", title: mainLanguage == "TH" ? "ค่า" : "Value" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        ,pageLength:100
    });
    BindEvent(g, d, ev);
}
function SetGridVender(p, g ,d ,ev) {
    $(g).DataTable({
        ajax: {
            url: p+'Master/GetVender', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'vender.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "VenCode", title: "รหัส" },
            { data: "TName", title: "ชื่อ" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        ,pageLength:100
    });
    BindEvent(g, d, ev);
}
function SetGridSICode(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetServiceCode?Code=' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'servicecode.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "SICode", title: mainLanguage == "TH" ? "รหัส" : "Service Code" },
            { data: "NameThai", title: mainLanguage == "TH" ? "ความหมาย" :  "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        ,pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridSICodeFilter(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetServiceCode' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'servicecode.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "SICode", title: mainLanguage == "TH" ? "รหัส" :  "Service Code" },
            { data: "NameThai", title: mainLanguage == "TH" ? "ความหมาย" :  "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridSICodeByGroup(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetServiceCode?Group=' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'servicecode.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "SICode", title: mainLanguage == "TH" ? "รหัส" :  "Service Code" },
            { data: "NameThai", title: mainLanguage == "TH" ? "ความหมาย" :  "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridDocument(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Acc/GetDocBalance' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'document.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "DocNo", title: mainLanguage == "TH" ? "เลขที่" :  "Cheque No" },
            {
                data: null, title: mainLanguage == "TH" ? "วันที่เช็ค" : "Cheque Date",
                render: function (data) {
                    return CDateTH(data.VoucherDate);
                }
            },
            { data: "CreditAmount", title: mainLanguage == "TH" ?  "ยอดเงินที่ตั้งไว้" :"Amount" },
            { data: "AmountUsed", title: mainLanguage == "TH" ?  "ยอดเงินที่ใช้" :"Used" },
            { data: "AmountRemain", title: mainLanguage == "TH" ? "ยอดเงินคงเหลือ" :"Balance" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCheque(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Acc/GetCheque' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'cheque.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "ChqNo", title: mainLanguage == "TH" ?  "เลขที่" :"Cheque No" },
            {
                data: null, title: mainLanguage == "TH" ? "วันที่เช็ค" :"Cheque Date",
                render: function (data) {
                    return CDateTH(data.ChqDate);
                }
            },
            { data: "ChqAmount", title: mainLanguage == "TH" ? "ยอดเงินหน้าเช็ค" :"Amount" },
            { data: "AmountUsed", title: mainLanguage == "TH" ? "ยอดเงินที่ใช้" :"Used" },
            { data: "AmountRemain", title: mainLanguage == "TH" ? "ยอดเงินคงเหลือ" :"Balance" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCustomsUnit(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCustomsUnit', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'customsunit.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "Code", title: mainLanguage == "TH" ? "รหัส" :  "Code" },
            { data: "TName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description"  }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridAccountCode(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetAccountCode'+ t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'accountcode.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "AccCode", title: mainLanguage == "TH" ? "รหัส" : "Code" },
            { data: "AccTName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCurrency(p, g , d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCurrency', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'currency.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "Code", title: mainLanguage == "TH" ? "รหัส" : "Code" },
            { data: "TName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridGroupCode(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetServiceGroup', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'servicegroup.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "GroupCode", title: mainLanguage == "TH" ? "รหัส" : "Code" },
            { data: "GroupName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridUnit(p, g ,d ,ev) {
    $.get(p + 'master/getcustomsunit')
        .done(function (r) {
            let dr = r.customsunit.data;
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "Code", title: mainLanguage == "TH" ? "รหัส" : "Code" },
                        { data: "TName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            }
        });

}
function SetGridBranch(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Config/GetBranch', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'branch.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "Code", title: mainLanguage == "TH" ? "รหัส" : "Code" },
            { data: "BrName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridUser(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetUser', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'user.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "UserID", title: mainLanguage == "TH" ? "รหัส" : "ID" },
            { data: "TName", title: mainLanguage == "TH" ? "ชื่อ" : "Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCompanyByGroup(p, g,t, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCompany?Group=' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'company.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "CustCode", title: mainLanguage=="TH" ? "รหัส" : "Code" },
            { data: "Branch", title: mainLanguage == "TH" ? "สาขา" : "Branch" },
            { data: "NameThai", title: mainLanguage == "TH" ? "ชื่อ" : "Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCompany(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCompany', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'company.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "CustCode", title: mainLanguage == "TH" ? "รหัส" : "Code" },
            { data: "Branch", title: mainLanguage == "TH" ? "สาขา" : "Branch" },
            { data: "NameThai", title: mainLanguage == "TH" ? "ชื่อ" : "Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCustContact(p, g, t, d, ev) {
    $.get(p + 'master/getcompanycontact' + t)
        .done(function (r) {
            let dr = r.companycontact.data;
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "ContactName", title: mainLanguage == "TH" ? "ชื่อผู้ติดต่อ" :"Contact" },
                        { data: "Department", title: mainLanguage == "TH" ?"แผนก":"Department" },
                        { data: "Position", title: mainLanguage == "TH" ? "ตำแหน่ง":"Position" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page,
                    responsive: true
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            } else {
                ShowMessage('Not Found Contact of This Company',true);
            }
        });
}
function SetGridDataDistinct(p, g, t, d, ev) {
    $.get(p + 'joborder/getdatadistinct' + t)
        .done(function (r) {
            let dr = r
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "val", title: "Data List" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            }
        });
}
function SetGridInv(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'acc/getinvheader' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'invheader.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "DocNo", title: mainLanguage == "TH" ? "เลขที่ใบแจ้งหนี้":"Invoice No" },
            { data: "CustCode", title: mainLanguage == "TH" ? "ลูกค้า" : "Customer" },
            { data: "TotalNet", title: mainLanguage == "TH" ? "ยอดรวม" : "Total" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridJob(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'joborder/getjobsql'+ t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'job.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "JNo", title: mainLanguage == "TH" ? "หมายเลขงาน":"Job No" },
            { data: "InvNo", title: mainLanguage == "TH" ?"อินวอยลูกค้า": "Cust Inv" },
            { data: "BookingNo", title: mainLanguage == "TH" ? "บุคกิ้ง" : "Booking" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridTransport(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'joborder/gettransportreport' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'transport.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "JNo", title: mainLanguage == "TH" ? "หมายเลขงาน": "Job No" },
            { data: "BookingNo", title: mainLanguage == "TH" ? "เลขที่บุคกี้ง": "BookingNo" },
            { data: "CTN_NO", title: mainLanguage == "TH" ? "เบอร์ตู้": "Container" },
            { data: "TruckNO", title: mainLanguage == "TH" ?"ทะเบียนรถ": "Truck" },
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridInterPort(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetInterPort?Key=' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'interport.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "PortCode", title: mainLanguage == "TH" ?"รหัส":"Code" },
            { data: "CountryCode", title: mainLanguage == "TH" ?"ประเทศ":"Country" },
            { data: "PortName", title: mainLanguage == "TH" ? "ชื่อ" : "Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCountry(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCountry', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'country.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "CTYCODE", title: mainLanguage == "TH" ? "รหัส":"Country" },
            { data: "CTYName", title: mainLanguage == "TH" ?"ชื่อประเทศ":"Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridWeightUnit(p, g, d, ev) {
    $.get(p + 'joborder/getjobdatadistinct?field=GWUnit')
        .done(function (r) {
            let dr = r
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "val", title: "value" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            }
        });

}
function SetGridVessel(p, g, d, t, ev) {
    $.get(p + 'master/getvessel?type='+ t )
        .done(function (r) {
            let dr = r.vessel.data;
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "TName", title: mainLanguage == "TH" ? "ชื่อเรือ":"Name" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            }
        });
}
function SetGridDeclareType(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetDeclareType', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'RFDCT.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "Type", title: mainLanguage == "TH" ?"รหัส":"Code" },
            { data: "Description", title: mainLanguage == "TH" ?"คำอธิบาย":"Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCustomsPort(p, g, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCustomsPort', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'RFARS.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "AreaCode", title: mainLanguage == "TH" ? "รหัส":"Code" },
            { data: "AreaName", title: mainLanguage == "TH" ?"คำอธิบาย":"Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridServUnit(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetServUnit', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'servunit.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "UnitType", title: mainLanguage == "TH" ? "รหัส":"Code" },
            { data: "UName", title: mainLanguage == "TH" ? "คำอธิบาย":"Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridServUnitFilter(p, g, t, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetServUnit' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'servunit.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "UnitType", title: mainLanguage == "TH" ?"รหัส":"Code" },
            { data: "UName", title: mainLanguage == "TH" ?"คำอธิบาย":"Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridProjectName(p, g, d, ev) {
    $.get(p + 'joborder/getjobdatadistinct?field=ProjectName')
        .done(function (r) {
            let dr = r
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "val", title: mainLanguage == "TH" ? "ชื่อโครงการ" :"Project Name"}
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            }
        });
}
function SetGridInvProduct(p, g, d, ev) {
    $.get(p + 'joborder/getjobdatadistinct?field=InvProduct')
        .done(function (r) {
            let dr = r;
            if (dr.length > 0) {
                $(g).DataTable({
                    data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "val", title: mainLanguage == "TH" ?"ชื่อสินค้า":"Product" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                BindEvent(g, d, ev);
            }
        });
}
function SetGridProvince(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetProvince', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'province.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "ProvinceCode", title: mainLanguage == "TH" ?"รหัส":"Code" },
            { data: "ProvinceName", title: mainLanguage == "TH" ?"คำอธิบาย":"Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridProvinceSub(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetProvinceSub'+ t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'province.detail'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "District", title: mainLanguage == "TH" ?"อำเภอ":"District" },
            { data: "SubProvince", title: mainLanguage == "TH" ?"ตำบล":"Sub-District" },
            { data: "PostCode", title: mainLanguage == "TH" ?"รหัสไปรษณีย์":"Post Code" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridBank(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetBank', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'bank.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "Code", title: mainLanguage == "TH" ?"รหัส":"Code" },
            { data: "BName", title: mainLanguage == "TH" ?"คำอธิบาย":"Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridBookAccount(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetBookAccount', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'bookaccount.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "BookCode", title: mainLanguage == "TH" ?"รหัส":"Book.No" },
            { data: "BookName", title: mainLanguage == "TH" ?"คำอธิบาย":"Description" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridPayment(p, g, t, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Acc/GetPaymentGrid' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'payment.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "DocNo", title: mainLanguage == "TH" ? "เลขที่" :"Doc.No" },
            { data: "VenCode", title: mainLanguage == "TH" ? "ผู้ให้บริการ":"Vender" },
            {
                data: "DocDate", title: mainLanguage == "TH" ?"กำหนดชำระ":"Due.Date",
                render: function (data) {
                    return CDateTH(data);
                }
            },
            { data: "SDescription", title: mainLanguage == "TH" ?"ค่าใช้จ่าย": "Expense" },
            { data: "Total", title: mainLanguage == "TH" ? "ยอดเงิน" : "Total" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridQuotationDesc(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'JobOrder/GetQuotationGrid' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'quotation.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "QNo", title: mainLanguage == "TH" ?"เลขที่ใบเสนอราคา":"Quotation No" },
            { data: "SeqNo", title: mainLanguage == "TH" ?"ข้อ":"Seq" },
            { data: "DescriptionThai", title: mainLanguage == "TH" ?"คำอธิบาย": "Desc" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridQuotation(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'JobOrder/GetQuotationGrid' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'quotation.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "QNo", title: "Quotation No" },
            { data: "SICode", title: "Code" },
            { data: "DescriptionThai", title: "Description" },
            { data: "ChargeAmt", title: "Price" },
            { data: "VenderCode", title: "Vender" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridJournal(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'acc/getjournalentry' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'journal.header'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "GLRefNo", title: mainLanguage == "TH" ?"เลขที่ลงบัญชี":"Batch No" },
            { data: "Remark", title: mainLanguage == "TH" ?"บันทึก": "Remark" },
            { data: "TotalDebit", title: "Debit" },
            { data: "TotalCredit", title: "Credit" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridTransportPrice(p, g, d, t, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'joborder/gettransportprice' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'transportprice.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "LocationID", title: mainLanguage == "TH" ? "เส้นทาง" : "Location" },
            { data: "Location", title: mainLanguage == "TH" ? "เส้นทาง" : "Location" },
            { data: "SDescription", title: mainLanguage == "TH" ? "ค่าใช้จ่าย" : "Expense" },
            { data: "CostAmount", title: mainLanguage == "TH" ?"ยอดเงิน": "Amount" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridTransportRoute(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'joborder/gettransportroute', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'transportroute.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "LocationID", title: mainLanguage == "TH" ?"รหัส": "id" },
            { data: "LocationRoute", title: mainLanguage == "TH" ?"เส้นทาง":"Route" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCompanyLogin(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCompany', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'company.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "LoginName", title: mainLanguage == "TH" ?"รหัส":"Log-in" },
            { data: "NameThai", title: mainLanguage == "TH" ?"ชื่อ":"Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridVenderLogin(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetVender', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'vender.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "LoginName", title: mainLanguage == "TH" ?"รหัส":"Log-in" },
            { data: "TName", title: mainLanguage == "TH" ?"ชื่อ":"Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridLocationEntry(p, g, d, t, ev) {
    $.get(p + 'joborder/getlocationentry' + t).done(function (r) {
        if (r.data[0].Table.length > 0) {
            let dr = r.data[0].Table;
            $(g).DataTable({
                data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: null, title: "#" },
                    { data: "Place", title: "Place" }
                ],
                "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                    {
                        "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                        "data": null,
                        "render": function (data, type, full, meta) {
                            let html = "<button class='btn btn-warning'>Select</button>";
                            return html;
                        }
                    }
                ],
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            BindEvent(g, d, ev);
        }
    });
}
function SetGridLocation(p, g, d, t, ev) {
    $.get(p + 'joborder/getlocation' + t).done(function (r) {
        if (r.data[0].Table.length > 0) {
            let dr = r.data[0].Table;
            $(g).DataTable({
                data: dr, //web service ที่จะ call ไปดึงข้อมูลมา
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: null, title: "#" },
                    { data: "Place", title: "Place" }
                ],
                "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                    {
                        "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                        "data": null,
                        "render": function (data, type, full, meta) {
                            let html = "<button class='btn btn-warning'>Select</button>";
                            return html;
                        }
                    }
                ],
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            BindEvent(g, d, ev);
        }
    });
}
function SetGridCompanyByVender(p, g, t, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCompany?Vend=' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'company.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "CustCode", title: mainLanguage == "TH" ? "รหัส" : "Code" },
            { data: "Branch", title: mainLanguage == "TH" ? "สาขา" : "Branch" },
            { data: "NameThai", title: mainLanguage == "TH" ? "ชื่อ" : "Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridBookBalance(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetBookBalance', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'bookaccount.data[0].Table'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "BookCode", title: mainLanguage == "TH" ? "รหัส" : "Book.No" },
            { data: "BookName", title: mainLanguage == "TH" ? "คำอธิบาย" : "Description" },
            { data: "SumBal", title: mainLanguage == "TH" ? "คงเหลือ" : "Balance" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridEstimateCost(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'Adv/GetClearExpReport' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'estimate.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "SICode", title: "Code" },
            { data: "SDescription", title: "Description" },
            { data: "AmtTotal", title: "Price" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridAddFuel(p, g, t, d, ev) {
    //popup for search data
    $(g).DataTable({
        ajax: {
            url: p + 'JobOrder/GetAddFuel' + t, //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'addfuel.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "DocNo", title: "No" },
            { data: "JNo", title: "Job" },
            {
                data: "DocDate", title: "Date",
                render: function (data) {
                    return CDateEN(data);
                }
            },
            {
                data: "TotalAmount", title: "Total",
                render: function (data) {
                    return ShowNumber(data, 2);
                }
            },
            {
                data: null, title: "Status",
                render: function (data) {
                    switch (true) {
                        case data.CancelBy !== null:
                            return 'Cancel';
                        case data.ApproveBy !== null:
                            return 'Approve';
                        default:
                            return 'Request';
                    }
                }
            },
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridCar(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetCarLicense', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'carlicense.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "CarNo", title: mainLanguage == "TH" ? "รหัสรถ" : "Code" },
            { data: "CarLicense", title: mainLanguage == "TH" ? "เลขทะเบียนรถ" : "License Number" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}
function SetGridEmployee(p, g, d, ev) {
    $(g).DataTable({
        ajax: {
            url: p + 'Master/GetEmployee', //web service ที่จะ call ไปดึงข้อมูลมา
            dataSrc: 'employee.data'
        },
        selected: true, //ให้สามารถเลือกแถวได้
        columns: [ //กำหนด property ของ header column
            { data: null, title: "#" },
            { data: "EmpCode", title: mainLanguage == "TH" ? "รหัสพนักงาน" : "Code" },
            { data: "Name", title: mainLanguage == "TH" ? "ชื่อพนักงาน" : "Employee Name" }
        ],
        "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Select</button>";
                    return html;
                }
            }
        ],
        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        , pageLength: 100
    });
    BindEvent(g, d, ev);
}