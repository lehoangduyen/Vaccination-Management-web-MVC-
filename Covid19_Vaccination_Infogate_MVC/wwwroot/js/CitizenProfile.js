$(document).ready(function () {
    // LOAD FRONT END DATA
    menu_title = '<a href="/Citizen/Profile">Thông tin công dân</a>'
    $('#function-navigation-bar-title').html(menu_title)

    homepage = '<a href="/Home">Trang chủ</a>'
    $('#homepage-path').html(homepage)

    subpage = '<a href="/Citizen/Profile">Công dân</a>'
    $('#subpage-path').html(subpage)

    selected_function = '<a href="/Citizen/Profile">Thông tin công dân</a>'
    $('#selected-function-path').html(selected_function)

    $('#function-menu-title').text('Trang công dân')

    menu = '<br><a href="/Citizen/AccountInfo"><li>Thông tin tài khoản</li></a>'
    menu += '<br><a href="/Citizen/Profile"><li>Thông tin công dân</li></a>'
    menu += '<br><a href="/Citizen/Registration"><li>Lịch đăng ký tiêm chủng</li></a>'
    menu += '<br><a href="/Citizen/Certificate"><li>Chứng nhận tiêm chủng</li></a>'
    menu += '<br><a href="#"><li>Tra cứu thông tin</li></a>'
    menu += '<br><a href="#"><li>Thêm người thân</li></a>'

    $('#function-menu-list').find('ul').html(menu)
    // END LOAD FRONT END DATA

    $('#cancel-update-profile').click(function () {
        location.reload()
    })

    $('#update-profile').click(function () {
        $('.message').html('')

        lastname = $('#info-panel').find('input[name="lastname"]').val()
        firstname = $('#info-panel').find('input[name="firstname"]').val()
        if (firstname == '') {
            $('.msg2').html('Nhập tên người dùng!')
            return
        }
        gender = $('#info-panel').find('select[name="gender"] option:selected').val()
        id = $('#info-panel').find('input[name="id"]').val()
        if (id == '') {
            $('.msg4').html('Nhập mã định danh!')
            return
        }
        birthday = $('#info-panel').find('input[name="birthday"]').val()
        if (birthday == '') {
            $('.msg5').html('Nhập ngày sinh!')
            return
        }
        hometown = $('#select-hometown').find('option:selected').text()
        if (hometown == '') {
            $('.msg6').html('Nhập quê quán!')
            return
        }
        province = $('#select-province').find('option:selected').text()
        if (province == '') {
            $('.msg7').html('Nhập tỉnh/thành phố thường trú!')
            return
        }
        district = $('#select-district').find('option:selected').text()
        if (district == '') {
            $('.msg8').html('Nhập quận/huyện thường trú')
            return
        }
        town = $('#select-town').find('option:selected').text()
        if (town == '') {
            $('.msg9').html('Nhập xã/phường thường/thị trấn trú!')
            return
        }
        street = $('#info-panel').find('input[name="street"]').val()
        email = $('#info-panel').find('input[name="email"]').val()

        $.ajax({
            cache: false,
            url: '/Citizen/UpdateProfile',
            type: 'POST',
            data: {
                lastname: lastname, firstname: firstname,
                gender: gender, id: id, birthday: birthday, hometown: hometown, province: province,
                district: district, town: town, street: street, email: email
            },
            success: function (result) {
                if (result.message.substring(0, 3) == 'ORA') {    //EXCEPTION
                    switch (data.substring(4, 9)) {
                        case '20000':
                            PopupConfirm('Độ tuổi của bạn nhỏ hơn quy định tiêm chủng!')
                            return
                        case '20001':
                            PopupConfirm('Bạn phải hoàn thành lượt đăng ký tiêm chủng hiện có trước khi thực hiện đăng ký lịch tiêm chủng mới!')
                            return
                        case '20002':
                            PopupConfirm('Bạn đã hoàn thành tất cả các liều tiêm chủng!')
                            return
                        case '20003':
                            PopupConfirm('Không thể đăng ký lịch tiêm này vì không phù hợp với khoảng cách thời gian tiêm chủng được quy định!')
                            return
                        case '20004':
                            PopupConfirm('Không thể đăng ký lịch tiêm này vì không phù hợp với loại vaccine tiêm chủng được quy định!')
                            return
                        case '20005':
                            PopupConfirm('Bạn phải thực hiện khai báo y tế trong vòng 7 ngày trước khi lịch tiêm diễn ra!')
                            return
                        case '20006':
                            PopupConfirm('Bạn đã bị nhiễm Covid-19 trong khoảng thời gian gần đây, xin chờ đến khi bạn hồi phục hoàn toàn!')
                            return
                        case '20007':
                            PopupConfirm('Bạn chưa thực hiện khai báo y tế trong 7 ngày gần đây!')
                            return
                        case '20008':
                            PopupConfirm('Tên không được bỏ trống!')
                            return
                        case '20009':
                            PopupConfirm('Ngày sinh không được là ngày trong tương lai!')
                            return
                        case '20010':
                            PopupConfirm('Số lượt đăng ký không thể là số âm!')
                            return
                        case '20011':
                            PopupConfirm('Số lượt đăng ký đã đạt giới hạn!')
                            return
                        case '20012':
                            PopupConfirm('Tên tài khoản/SĐT đã được sử dụng bởi một người dùng khác!')
                            return
                        case '20013':
                            PopupConfirm('Sai mật khẩu!')
                            return
                        case '20014':
                            PopupConfirm('Tên tài khoản/SĐT không tồn tại!')
                            return
                        case '20015':
                            PopupConfirm('CCCD hoặc SĐT đã được sử dụng bởi một người dùng khác!')
                            return
                        case '20016':
                            PopupConfirm('Mã vaccine hoặc tên vaccine đã được sử dụng để đăng ký thông tin!')
                            return
                        case '20017':
                            PopupConfirm('Thông tin trống!')
                            return
                        case '20018':
                            PopupConfirm('Tài khoản đang được đăng nhập')
                            return
                        case '20019':
                            PopupConfirm('Mật khẩu không đúng')
                            return
                        case '20020':
                            PopupConfirm('Không thể cập nhật, số lượt đăng ký đã vượt giới hạn!')
                            return
                        case '20021':
                            PopupConfirm('Đã tồn tại một lịch tiêm cùng ngày và cùng loại vaccine!')
                        case '20022':
                            PopupConfirm('Đã tồn tại một lịch tiêm cùng ngày và cùng lọai vaccine!')
                            return
                        case '20023':
                            PopupConfirm('Số lượng phải là một số dương!')
                            return
                        default:
                            PopupConfirm('Lỗi!')
                            return
                    }
                }
                switch (result.message) {
                    case 'UpdateProfile':
                        $('.form-message').text('Cập nhật thông tin thành công!')
                        break
                    case '':
                        $('.form-message').text('Lỗi chưa xác định!')
                        break
                    default:
                        alert(result.message)
                        break
                }

                $('#form-popup-confirm').css('display', 'grid')
                $('#gradient-bg-faded').css('display', 'block')

                $('#form-popup-confirm').find('.btn-confirm').click(function () {
                    location.reload()
                })
            },
            error: function () {
            }
        })
    })
})

