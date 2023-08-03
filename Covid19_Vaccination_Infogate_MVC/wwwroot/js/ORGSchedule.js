$(document).ready(function () {

    // LOAD FRONT END DATA
    menu_title = '<a href="/ORG/Schedule">Danh sách lịch tiêm</a>'
    $('#function-navigation-bar-title').html(menu_title)

    homepage = '<a href="index">Trang chủ</a>'
    $('#homepage-path').html(homepage)

    subpage = '<a href="/ORG/Schedule">Lịch tiêm</a>'
    $('#subpage-path').html(subpage)

    selected_function = '<a href="/ORG/Schedule">Danh sách lịch tiêm</a>'
    $('#selected-function-path').html(selected_function)
    // END LOAD FRONT END DATA

    var today = new Date()
    var day = ('0' + today.getDate()).slice(-2)
    var month = ('0' + (today.getMonth() + 1)).slice(-2)
    var today = today.getFullYear() + '-' + (month) + '-' + (day)
    $('#start-date').val(today)
    // $('#end-date').val(today)

    // LOAD SCHEDULE DATA
    LoadSchedule($('.orgid').attr('id'))

    $('#filter-schedule').change(function () {
        $('#list-registration').html('')
        $('.list-name-registration').text('')
        $('#filter-registration').css('display', 'none')
        LoadSchedule($('.orgid').attr('id'))

    })

    function LoadSchedule(orgid) {
        startdate = $('#start-date').val()
        enddate = $('#end-date').val()

        $.ajax({
            cache: false,
            url: '/ORG/LoadSchedule',
            type: 'POST',
            data: { orgid: orgid, startdate: startdate, enddate: enddate },
            success: function (data) {
                if (data.substring(4, 9) == 'ORA') {    //EXCEPTION
                    alert(data)
                    return
                }
                $('#list-schedule').html(data)
            },
            error: function (error) {
            }
        })
    }

    // HANDLE SELECT SCHEDULE
    $('#list-schedule').on('click', '.schedule .holder-btn-expand-schedule', function () {
        $('#list-registration').html('')
        schedule = $(this).parent()//.parent()
        if (schedule.css('margin-top') == '20px') {
            $('#list-registration').html('')
            schedule.css('margin', '3px 0px 3px 5px')
            schedule.css('width', '92%')
            schedule.css('height', '70px')
            schedule.find('.btn-expand-schedule').text('>')
            schedule.find('.interactive-area').css('display', 'none')
            return
        }
        $('#list-schedule').find('.schedule').css('margin', '3px 0px 3px 5px')
        $('#list-schedule').find('.schedule').css('width', '92%')
        $('#list-schedule').find('.schedule').css('height', '70px')
        $('#list-schedule').find('.schedule .btn-expand-schedule').text('>')
        $('#list-schedule').find('.schedule .interactive-area').css('display', 'none')

        schedule.css('margin', '20px 0px 20px 12px')
        schedule.css('width', '95%')
        schedule.css('height', '115px')
        schedule.find('.btn-expand-schedule').text('<')
        schedule.find('.interactive-area').css('display', 'block')
    })

    // HANDLE QUERY SCHEDULE'S REGISTRATION
    $('#list-schedule').on('click', '.btn-registration', function () {
        schedule = $(this).parent().parent().parent()
        SchedID = schedule.attr('id')
        SchedInfo = schedule.find('.obj-attr').find('.attr-date-vaccine-serial').text()
        $('.list-name-scheduleinfo').text(SchedInfo)
        LoadScheduleRegistration(SchedID, SchedInfo.substring(11, 21))
    })

    $('#filter-registration').change(function () {
        SchedID = $('.list-name-registration').attr('id')
        LoadScheduleRegistration(SchedID)
    })

    function LoadScheduleRegistration(SchedID, date) {
        time = $('#time').find('option:selected').val()
        status = $('#status').find('option:selected').val()

        $.ajax({
            cache: false,
            url: '/ORG/LoadScheduleRegistration',
            type: 'POST',
            data: { SchedID: SchedID, date: date, time: time, status: status },
            indexValue: { SchedID: SchedID },
            success: function (data) {
                if (data.substring(4, 9) == 'ORA') {    //EXCEPTION
                    alert(data)
                    return
                }
                if (data == '') {
                    PopupConfirm('Không có lượt đăng ký nào cho lịch tiêm này.')
                }

                $('#list-registration').html(data)
                $('.list-name-registration').text('DANH SÁCH LƯỢT ĐĂNG KÝ')
                $('.list-name-registration').attr('id', this.indexValue.SchedID)
                $('#filter-registration').css('display', 'block')
            },
            error: function (error) {
            }
        })
    }

    // HANDLE UPDATE REGISTRATION STATUS
    $('#list-registration').on('click', '.btn-update-registration', function () {
        citizenid = $(this).parent().parent().parent().find('.obj-name').attr('id')
        SchedID = $(this).parent().parent().parent().attr('id')
        status = $(this).parent().find('.select-status').find('option:selected').val()
        $.ajax({
            cache: false,
            url: '/ORG/UpdateRegistrationStatus',
            type: 'POST',
            data: { citizenid: citizenid, SchedID: SchedID, status: status },
            indexValue: { reg: $(this).parent().parent().parent() },
            success: function (data) {
                if (data.substring(4, 9) == 'ORA') {    //EXCEPTION
                    alert(data)
                    return
                }

                reg = this.indexValue.reg
                switch (data) {
                    case '1':
                        reg.find('.hoder-obj-attr .interactive-area select').html('<option value="2">Đã tiêm</option><option value="3">Đã hủy</option>')
                        reg.find('.hoder-obj-attr .obj-attr .attr-detail p:last-child').text('Tình trạng: Đã điểm danh')
                        break
                    case '2':
                        reg.find('.hoder-obj-attr .interactive-area select').html('ImageIcon stay here!')
                        break
                    case '3':
                        this.indexValue.reg.remove()
                        LoadSchedule($('.orgid').attr('id'))
                        break
                    default:
                        break
                }
            },
            error: function (error) {
            }
        })

    })

    // HANDLE ENTER UPDATE SCHEDULE PANEL
    $('#list-schedule').on('click', '.btn-update', function () {
        schedule = $(this).parent().parent().parent()
        SchedID = schedule.attr('id')
        SchedInfo = schedule.find('.obj-attr .attr-date-vaccine-serial').text()
        SchedValue = schedule.find('.obj-attr .attr-time').text()

        $.ajax({
            cache: false,
            url: '/ORG/SelectScheduleValue',
            type: 'POST',
            data: { SchedID: SchedID },
            success: function (data) {
            },
            error: function (error) {
            }
        })

        $('#list-registration').html(
            '<div class="panel-update-schedule" id="' + SchedID + '">'
            + '<br>'
            + '<div class="schedule-id">Mã lịch tiêm: ' + SchedID + '</div>'
            + '<div class="attr-date-vaccine-serial">' + SchedInfo + '</div>'
            + '<div class="attr-time">' + SchedValue + '</div>'
            + '<div class="container-update-value">'
            + '<label for="limit-day" class="">Giới hạn đăng ký buổi sáng</label><br>'
            + '<input id="limit-day" type="number" min="0"><br>'
            + '<label for="limit-noon" class="">Giới hạn đăng ký buổi chiều</label><br>'
            + '<input id="limit-noon" type="number" min="0"><br>'
            + '<label for="limit-night" class="">Giới hạn đăng ký buổi tối</label><br>'
            + '<input id="limit-night" type="number" min="0"><br>'
            + '<button class="btn-medium-bordered" id="btn-confirm-update-schedule">Xác nhận</button>'
            + '</div>'
            + '</div>'
        )
    })

    // HANDLE UPDATE SCHEDULE VALUE
    $('#list-registration').on('click', '#btn-confirm-update-schedule', function () {
        SchedID = $(this).parent().parent().attr('id')
        orgid = SchedID.substring(4, 9)
        limitday = $('#limit-day').val()
        limitnoon = $('#limit-noon').val()
        limitnight = $('#limit-night').val()

        if (limitday < 0 || limitnoon < 0 || limitnight < 0) {
            PopupConfirm('Các giá trị giới hạn không thể là số âm!')
            return
        }

        if (limitday == '')
            limitday = -1

        if (limitnoon == '')
            limitnoon = -1

        if (limitnight == '')
            limitnight = -1

        $.ajax({
            cache: false,
            url: '/ORG/UpdateSchedule',
            type: 'POST',
            data: { SchedID: SchedID, limitday: limitday, limitnoon: limitnoon, limitnight: limitnight },
            success: function (data) {
                if (data.substring(0, 3) == 'ORA') {    //EXCEPTION
                    switch (data.substring(4, 9)) {
                        case '20020':
                            PopupConfirm('Không thể cập nhật giới hạn đăng ký xuống thấp hơn số lượng đã đăng ký!')
                            return
                        default:
                            PopupConfirm('Lỗi!')
                            return
                    }
                }
                if (data == 'UpdateSchedule') {
                    $('.panel-update-schedule').html('')
                    PopupConfirm('Cập nhật lịch tiêm thành công!')
                    LoadSchedule(orgid)
                }
            },
            error: function (error) {
            }
        })
    })

    // HANDLE CANCEL SCHEDULE
    $('#list-schedule').on('click', '.btn-cancel', function () {
        if (confirm('Xác nhận hủy lịch tiêm chủng này?')) {
            $('#list-registration').html('')
            schedule = $(this).parent().parent().parent()
            SchedID = schedule.attr('id')
            $.ajax({
                cache: false,
                url: '/ORG/CancelSchedule',
                type: 'POST',
                data: { SchedID: SchedID },
                indexValue: { schedule: schedule },
                success: function (data) {
                    if (data.substring(4, 9) == 'ORA') {    //EXCEPTION
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
                    if (data == 'CancelSchedule') {
                        schedule.find('.obj-attr .attr-time .day').attr('id', 0)
                        schedule.find('.obj-attr .attr-time .day').text(0)
                        schedule.find('.obj-attr .attr-time .noon').attr('id', 0)
                        schedule.find('.obj-attr .attr-time .noon').text(0)
                        schedule.find('.obj-attr .attr-time .night').attr('id', 0)
                        schedule.find('.obj-attr .attr-time .night').text(0)
                        PopupConfirm('Hủy lịch tiêm thành công!')
                    }
                },
                error: function (error) {
                }
            })
        }
    })
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