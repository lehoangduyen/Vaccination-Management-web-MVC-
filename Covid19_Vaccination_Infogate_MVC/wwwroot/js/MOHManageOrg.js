$(document).ready(function () {

    // LOAD FRONT END DATA
    menu_title = '<a href="/ORG/ManageOrg">Quản lý đơn vị tiêm chủng</a>'
    $('#function-navigation-bar-title').html(menu_title)

    homepage = '<a href="/Home">Trang chủ</a>'
    $('#homepage-path').html(homepage)

    subpage = '<a href="/ORG/ManageOrg">Đơn vị tiêm chủng</a>'
    $('#subpage-path').html(subpage)

    selected_function = '<a href="/ORG/ManageOrg">Quản lý đơn vị tiêm chủng</a>'
    $('#selected-function-path').html(selected_function)

    $('#function-menu-title').text('Đơn vị tiêm chủng')

    menu = '<br><a href="/ORG/ManageOrg"><li>Quản lý đơn vị</li></a>'
    menu += '<br><a href="/ORG/ProvideOrgAcc"><li>Cấp tài khoản đơn vị</li></a>'

    $('#function-menu-list').find('ul').html(menu)
    // END LOAD FRONT END DATA

    LoadOrg()

    $('#btn-filter-org').click(function () {
        LoadOrg()
    })

    function LoadOrg() {
        province = $('#select-province').find('option:selected').text()
        district = $('#select-district').find('option:selected').text()
        town = $('#select-town').find('option:selected').text()

        $.ajax({
            cache: false,
            url: '/ORG/LoadOrg',
            type: 'POST',
            data: { province: province, district: district, town: town },
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
                $('#list-org').html(data)
            },
            error: function (error) {
            }
        })
    }
})

