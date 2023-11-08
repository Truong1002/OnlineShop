var user = {
    init: function () {
        user.loadProvince();
        user.registerEvent1();
        user.registerEvent2();
    },
    registerEvent1: function () {
        $('#ddlProvince').off('change').on('change', function () {
            var id = $(this).val();
            if (id != '') {
                user.loadDistrict(parseInt(id));
            } else {
                $('#ddlDistrict').html(''); 
            }
        }); 
    },

    registerEvent2: function () {
        $('#ddlDistrict').off('change').on('change', function () {
            var districtID = $(this).val();
            var provinceID = $('#ddlProvince').val(); // Lấy giá trị của tỉnh từ dropdown tỉnh
            if (districtID != '') {
                user.loadPrecinct(parseInt(districtID), parseInt(provinceID)); // Truyền cả hai biến
            } else {
                $('#ddlPrecinct').html('');
            }
        });
    },
    loadProvince: function () {
        
        $.ajax({
            url: '/User/LoadProvince',
            type: "POST",
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn tỉnh thành--</opton>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value = "' + item.ID + '">' + item.Name + '</option>'
                    });
                    $('#ddlProvince').html(html);
                }
            }
        })
    },

    loadDistrict: function (id) {

        $.ajax({
            url: '/User/LoadDistrict',
            type: "POST",
            data: {provinceID: id},
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn quận huyện--</opton>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value = "' + item.ID + '">' + item.Name + '</option>'
                    });
                    $('#ddlDistrict').html(html);
                }
            }
        })
    },

    loadPrecinct: function (districtID, provinceID) {

        $.ajax({
            url: '/User/LoadPrecinct',
            type: "POST",
            data: { districtID: districtID, provinceID: provinceID },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn xã--</opton>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value = "' + item.ID + '">' + item.Name + '</option>'
                    });
                    $('#ddlPrecinct').html(html);
                }
            }
        })
    }
}
user.init();