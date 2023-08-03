$(document).ready(function () {
    // LOAD FRONT END DATA
    menu_title = '<a href="/Citizen/MedicalForm">Tờ khai y tế</a>'
    $('#function-navigation-bar-title').html(menu_title)

    homepage = '<a href="/Home">Trang chủ</a>'
    $('#homepage-path').html(homepage)

    subpage = '<a href="/Citizen/MedicalForm">Khai báo</a>'
    $('#subpage-path').html(subpage)

    selected_function = '<a href="/Citizen/MedicalForm">Tờ khai y tế</a>'
    $('#selected-function-path').html(selected_function)

    $('#function-menu-title').text('Trang khai báo y tế')

    menu = '<br><a href="/Citizen/MedicalForm"><li>Tờ khai y tế</li></a>'
    menu += '<br><a href="/Citizen/MedicalFormList"><li>Danh sách tờ khai</li></a>'

    $('#function-menu-list').find('ul').html(menu)

    var today = new Date()
    var day = ('0' + today.getDate()).slice(-2)
    var month = ('0' + (today.getMonth() + 1)).slice(-2)
    var today = today.getFullYear() + '-' + (month) + '-' + (day)
    $('#input-date').val(today)
    // END LOAD FRONT END DATA

    // HANDLE ACTION
    $('#btn-filter-org').click(function () {

        selectformlist()
    })

    function selectformlist() {
        formdate = $('#form-date').val()

        // filleddate = $('#input-date').val()
        // if (new Date (filleddate).getTime() > new Date().getTime()){
        //     alert('Ngày khai báo không hợp lệ!')
        //     return
        //

        $.ajax({
            cache: false,
            url: '/Citizen/MedicalList',
            type: 'POST',
            data: { formdate: formdate },
            success: function (data) {
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
                if (data == 'NoForm') {
                    PopupConfirm('Bạn chưa khai báo y tế trong vòng ' + formdate + ' ngày!')
                }
                $('#holder-form-medical').html(data);
            },
            error: function (error) {
                // $('body').html(error)
                alert('error')
            }
        })
    }
})

var PopupConfirm = function (message) {
    $('.form-message').html(message)
    $('#form-popup-confirm').css('display', 'grid')
    $('#gradient-bg-faded').css('display', 'block')
    $('#form-popup-confirm').find('.btn-confirm').click(function () {
        $('#form-popup-confirm').css('display', 'none')
        $('#gradient-bg-faded').css('display', 'none')
    })
}
