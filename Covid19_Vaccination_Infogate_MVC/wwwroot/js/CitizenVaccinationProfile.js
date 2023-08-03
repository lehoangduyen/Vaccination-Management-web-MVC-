{/* <link rel='stylesheet' href='css/function-menu.css'></link> */}
$(document).ready(function(){
    // LOAD FRONT END DATA
    menu_title = '<a href="/Citizen/VaccinationProfile">Tra cứu thông tin</a>'
    $('#function-navigation-bar-title').html(menu_title)

    homepage = '<a href="/Home">Trang chủ</a>'
    $('#homepage-path').html(homepage)
    
    subpage = '<a href="/Citizen/Profile">Công dân</a>'
    $('#subpage-path').html(subpage)

    $('#selected-function-path').html(menu_title)

    $('#function-menu-title').text('Trang công dân')

    menu = '<br><a href="/Citizen/AccountInfo"><li>Thông tin tài khoản</li></a>'
    menu += '<br><a href="/Citizen/Profile"><li>Thông tin công dân</li></a>'
    menu += '<br><a href="/Citizen/Registration"><li>Lịch đăng ký tiêm chủng</li></a>'
    menu += '<br><a href="/Citizen/Certificate"><li>Chứng nhận tiêm chủng</li></a>'
    menu += '<br><a href="#"><li>Tra cứu thông tin</li></a>'
    menu += '<br><a href="#"><li>Thêm người thân</li></a>'

    $('#function-menu-list').find('ul').html(menu_title)
    // END LOAD FRONT END DATA
})