var specialityItems = document.querySelectorAll(".speciality-item ")
specialityItems.forEach(item => {
    item.onclick = () => {
        var checked = item.classList.contains("sepciality-item--selected")
        if(checked){
            item.classList.remove("sepciality-item--selected")
        }else 
            item.classList.add("sepciality-item--selected")
    }
})

handleClickListJob = function(){
    var menu = document.querySelector(".select-group-job")
    checked = menu.classList.contains("hidden")
    if(checked){
        menu.classList.remove("hidden")
    }else 
    menu.classList.add("hidden")
}


//hover cong viec lien quan
// const containers = document.querySelectorAll(".container-job-item");
// containers.forEach(container => {
//     console.log(container)
// container.onmouseenter = () => {
//     const jobDetails = container.querySelector(".hover-job-detail");
//     // Hiện jobDetails khi trỏ chuột vào container
//     jobDetails.classList.remove("hidden");
//     console.log("da hover")
// };

// container.onmouseleave = () => {
//     // Ẩn jobDetails khi trỏ chuột ra khỏi container
//     jobDetails.classList.add("hidden");
// };

// })


// const container = document.querySelector(".container-job-item");
// const jobDetails = document.querySelector(".hover-job-detail");

// container.addEventListener("mouseenter", () => {
//     jobDetails.classList.remove("hidden"); // Hiển thị khi hover
// });

// container.addEventListener("mouseleave", () => {
//     jobDetails.classList.add("hidden"); // Ẩn khi không hover
// });



//cuon doi header
var scrollContainers = document.querySelectorAll(".scroll-js");
scrollContainers.forEach(s => {
    s.onscroll = () => {

        const currentScrollTop = s.scrollTop; 
        var headerLogo = s.querySelector('.hover-job-detail__header');
        var headerTitle = s.querySelector('.title-scroll');
      
        if (currentScrollTop === 0) { 
          headerLogo.classList.remove("hidden");
          headerTitle.classList.add("hidden");
        } else { 
          headerLogo.classList.add("hidden");
          headerTitle.classList.remove("hidden");
        }
      }; 
})


//MODAL
document.addEventListener('DOMContentLoaded', function () {
    const fileInput = document.getElementById('file-upload-cv');
    const fileInfo = document.querySelector('.file-info');
    const fileNameDisplay = document.querySelector('.file-info .file-name');
    const uploadBox = document.querySelector('.box-upload');
    const notCvBox = document.querySelector('.not-cv');

    fileInput.addEventListener('change', function () {
        if (fileInput.files.length > 0) {
            const fileName = fileInput.files[0].name; // Lấy tên file
            fileNameDisplay.textContent = fileName;

            // Hiển thị giao diện "Đã chọn file"
            fileInfo.style.display = 'block';
            notCvBox.style.display = 'none';
        }
    });

    // Thay đổi file khác
    document.querySelector('.change-file').addEventListener('click', function () {
        fileInput.value = ''; // Reset file input
        fileInfo.style.display = 'none'; // Ẩn thông tin file
        notCvBox.style.display = 'block'; // Hiển thị lại nút chọn CV
    });
});
