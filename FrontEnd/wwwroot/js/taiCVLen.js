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
