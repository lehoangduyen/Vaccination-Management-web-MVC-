$(document).ready(function () {
    $('#cancel-update-account-info').click(function () {
        location.reload()
    })

    $('#update-account-info').click(function () {
        $('.message').text("")
        phone = $('.account input[name="phone"]').val()
        if (phone == "") {
            $('.account').find('.msg1').text("Nhập số điện thoại!")
            return
        }

        password = $('.account input[name="password"]').val()
        if (password == "") {
            $('.account').find('.msg2').html("Nhập mật khẩu để xác nhận thay đổi<br>thông tin!")
            return
        }

        new_password = $('.change-pass input[name="new-password"]').val()
        repeat_new_password = $('.change-pass input[name="repeat-new-password"]').val()
        if (new_password != repeat_new_password) {
            $('.change-pass').find('.msg2').html("Nhập lại mật khẩu phải giống với<br> mật khẩu!")
            return
        }

        /*
        The jQuery.ajax() function below used to call php code back-end to process a request made by user.
        + 'cache' field set to false means the called php file/page not to be cached 
        (stored the data for future uses) by browser. Because, every request in almost cases must be done
        with the newest data.
        + 'url' field specifies the location of the requested .php file.
        + 'type' field specifies the method to send data to the called php file.
        + 'data' field defines the key-value to be sent to the called php file. So that can make it accessible
        + 'sucess' field defines a function to be called if the request succeeds.
        The parameter result.message stores the returned data which is returned by return echo header etc. statements.
        + 'error' field defines a function to be called if the request fails.
        The parameter error stores errors.
        */
        $.ajax({
            cache: false,
            url: '/Citizen/UpdateAccount',
            type: "POST",
            /*
            The requests to back-end code must send a key-value to verify that this is a right call.
            The verification can be do by the key-value of the calling method.
            The requested file also should be formated in function-oriented to make a reusable code.
            */
            data: { phone: phone, password: password, new_password: new_password },
            success: function (data) {
                /*
                In the php back-end code, catches the exception then return in a formated message,
                so that we can check back in this jQuery function and throw an optional message.
                */
                if (data.substring(0, 3) == 'ORA') {    //EXCEPTION
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

                /* 
                Back-end code obviously can return difference values every calls.
                Switch cases and handle!
                */
                switch (data) {
                    case 'Password is incorrect!':
                        $('.account').find('.msg2').html('Sai mật khẩu!')
                        return
                    case 'ChangePasswordUpdateAccount':
                        $('.form-message').text('Cập nhật tài khoản thành công!')
                        break
                    case 'ChangePassword!UpdateAccount':
                        $('.form-message').text('Cập nhật mật khẩu thành công!')
                        break
                    case '!ChangePasswordUpdateAccount':
                        $('.form-message').text('Cập nhật số điện thoại thành công!')
                        break
                    case '!ChangePassword!UpdateAccount':
                        return
                    case '':
                        $('.form-message').text('Lỗi chưa xác định!')
                        break
                    default:
                        alert(data)
                        break
                }

                $('#form-popup-confirm').css('display', 'grid')
                $('#gradient-bg-faded').css('display', 'block')

                $('#form-popup-confirm').find('.btn-confirm').click(function () {
                    location.reload()
                })
            },
            error: function (error) {
            }
        })
    })
})