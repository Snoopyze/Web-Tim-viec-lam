const templateBtn = document.querySelector(".btn_style_CV");
const cvContainer = document.getElementById("cv-container");
const closeBtn = document.getElementById("close-btn");
const selectContainer = document.getElementById("select-container");
// Hiển thị danh sách CV khi nhấn "Đổi mẫu CV"
templateBtn.addEventListener("click", () => {
    cvContainer.style.display = "flex";
    selectContainer.style.display = "none"; // Ẩn modal
});

// Ẩn danh sách CV khi nhấn nút đóng
closeBtn.addEventListener("click", () => {
    cvContainer.style.display = "none";
});
const changeCSS = (cssFile) => {
    const existingLink = document.getElementById("cv-stylesheet");
    if (existingLink) {
        existingLink.href = cssFile;
    } else {
        const link = document.createElement("link");
        link.rel = "stylesheet";
        link.id = "cv-stylesheet";
        link.href = cssFile;
        document.head.appendChild(link);
    }
};
document.querySelectorAll(".cv-item").forEach((item, index) => {
    item.addEventListener("click", () => {
        const cssFile = `../css/CV${index + 1}.css`; // Đặt tên file CSS: cv-style-1.css, cv-style-2.css, ...
        changeCSS(cssFile);
        cvContainer.style.display = "none"; // Ẩn danh sách sau khi chọn
    });
});





