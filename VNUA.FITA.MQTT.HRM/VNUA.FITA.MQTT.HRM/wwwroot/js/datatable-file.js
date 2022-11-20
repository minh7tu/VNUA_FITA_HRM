$(document).ready(function(){
    DanhSachNhanVien()
});
function DanhSachNhanVien() {
    $.ajax({
        url:'/ThongTinNhanVien/DanhSachNhanVien',
        type: 'Get',
        dataType: 'json',
        success: OnSuccess
})
}
function OnSuccess(response) {
    $('#dataTableData').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: ' IdNhanVien',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'Anh',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'MaNhanVien',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'HoTen',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'GioiTinh',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'NgaySinh',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'SDT',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'DiaChi',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'Email',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'TrinhDo',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'ChucVu',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },
            {
                data: 'SoCCCD',
                render: function (data, type, row, meta) {
                    return row.IdNhanVien
                }
            },

        ]
    });
}

