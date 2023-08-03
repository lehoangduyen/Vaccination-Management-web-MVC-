$(document).ready(function () {
    // LOAD FRONT END DATA
    menu_title = '<a href="/ORG/Profile">Thông tin đơn vị</a>';
    $('#function-navigation-bar-title').html(menu_title);

    homepage = '<a href="/Home">Trang chủ</a>';
    $('#homepage-path').html(homepage);

    subpage = '<a href="/ORG/Profile">Đơn vị</a>'
    $('#subpage-path').html(subpage);

    selected_function = '<a href="/ORG/Profile">Thông tin đơn vị</a>';
    $('#selected-function-path').html(selected_function);

    $('#function-menu-title').text('Trang đơn vị');

    menu = '<br><a href="/ORG/AccountInfo"><li>Thông tin tài khoản</li></a>';
    menu += '<br><a href="/ORG/Profile"><li>Thông tin đơn vị</li></a>';

    $('#function-menu-list').find('ul').html(menu);
    // END LOAD FRONT END DATA

    $("#cancel-update-profile").click(function () {
        location.reload();
    })

    $("#update-profile").click(function () {
        $('.message').html("");

        name = $('#info-panel input[name="name"]').val();
        if (name == "") {
            $('.msg2').html('Nhập tên đơn vị!');
            return;
        }
        district = $('#select-district').find('option:selected').text();
        if (district == "") {
            $('.msg8').html('Nhập quận/huyện thường trú');
            return;
        }
        town = $('#select-town').find('option:selected').text();
        if (town == "") {
            $('.msg9').html('Nhập xã/phường thường/thị trấn trú!');
            return;
        }
        street = $('#info-panel').find('input[name="street"]').val();

        $.ajax({
            cache: false,
            url: "/ORG/UpdateOrgProfile",
            type: "POST",
            data: { name: name, district: district, town: town, street: street },
            success: function (data) {
                $('.form-message').text('Cập nhật thông tin thành công!');
                $('#form-popup-confirm').css('display', 'block');
                $('.gradient-bg-faded').css('display', 'block');
                location.reload();
            },
            error: function () {

            }
        })
    })
})

