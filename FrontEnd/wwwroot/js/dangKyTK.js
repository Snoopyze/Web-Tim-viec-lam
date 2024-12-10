const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)

const tabs = $$('.tab-item')
const panes = $$('.tab-pane')

const tabActive = $('.tab-item.active')
const line = $('.tabs .line')

line.style.left = tabActive.offsetLeft + 'px'
line.style.width = tabActive.offsetWidth + 'px'

tabs.forEach((tab, index) => {
    const pane = panes[index]
    tab.onclick = function () {

        $('.tab-item.active').classList.remove('active')
        $('.tab-pane.active').classList.remove('active')

        line.style.left = this.offsetLeft + 'px'
        line.style.width = this.offsetWidth + 'px'

        this.classList.add('active')
        pane.classList.add('active')
    }

})


//SO SÁNH MẬT KHẨU

function checkPasswordForUV() {
    error = document.querySelector("#errorPassUV");
    password = document.getElementById("matKhauUV").value;
    retypePassword = document.getElementById("matKhauNhapLaiUV").value;
    if (password != retypePassword) {
        error.innerHTML = "Mật khẩu không khớp";
    } else
        error.innerHTML = "";
}


function checkPasswordForNTD() {
    error = document.querySelector("#errorPassNTD");
    password = document.getElementById("matKhauNTD").value;
    retypePassword = document.getElementById("matKhauNhapLaiNTD").value;
    if (password != retypePassword) {
        error.innerHTML = "Mật khẩu không khớp";
    } else
        error.innerHTML = "";
}
