document.addEventListener("DOMContentLoaded", function () {
    let blockCounter = 1; // Bộ đếm để tạo id duy nhất cho các content_block mới

    // Hàm thêm nội dung mới
    const addContentBlock = (contentBlock) => {
        const id = contentBlock.id; // Lấy id của content_block hiện tại
        const newContentBlock = document.createElement("div");
        newContentBlock.classList.add("content_block");

        // Tạo id cho newContentBlock
        newContentBlock.id = id;

        // Tạo nội dung mới dựa trên id
        switch (id) {
            case "info":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">📧 Điền email</div>
                    <div contenteditable="true">📞 Điền số điện thoại</div>
                    <div contenteditable="true">🔗 Điền liên kết</div>
                    <div contenteditable="true">📍 Điền địa chỉ</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "edu_lv":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Tên trường học</div>
                    <div contenteditable="true">Ngành học / Môn học</div>
                    <div contenteditable="true">Bắt đầu - Kết thúc</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "skill":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Tên kỹ năng</div>
                    <div contenteditable="true">Mô tả kỹ năng</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "exp":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Bắt đầu - Kết thúc</div>
                    <div contenteditable="true">Tên công ty</div>
                    <div contenteditable="true">Mô tả công việc</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "project":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Bắt đầu - Kết thúc</div>
                    <div contenteditable="true">Tên dự án</div>
                    <div contenteditable="true">Khách hàng</div>
                    <div contenteditable="true">Số lượng người tham gia</div>
                    <div contenteditable="true">Vị trí</div>
                    <div contenteditable="true">Công nghệ sử dụng</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "certificate":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Thời gian</div>
                    <div contenteditable="true">Tên chứng chỉ</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "activity":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Bắt đầu - Kết thúc</div>
                    <div contenteditable="true">Tên tổ chức</div>
                    <div contenteditable="true">Vị trí của bạn</div>
                    <div contenteditable="true">Mô tả hoạt động</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "prize":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Thời gian</div>
                    <div contenteditable="true">Tên giải thưởng</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "moreinfo":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Điền thông tin thêm nếu có</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "intro_person":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Tên người giới thiệu</div>
                    <div contenteditable="true">Chức vụ</div>
                    <div contenteditable="true">Thông tin liên hệ</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            case "hobby":
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Điền các sở thích của bạn</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
            default:
                newContentBlock.innerHTML = `
                    <div contenteditable="true">Nội dung mặc định</div>
                    <div class="controls2">
                        <button class="delete-btn">x</button>
                        <button class="add-btn">+</button>
                    </div>`;
                break;
        }

        // Gắn sự kiện cho các nút trong content_block mới
        const deleteBtn = newContentBlock.querySelector(".delete-btn");
        deleteBtn.addEventListener("click", function () {
            newContentBlock.remove(); // Xóa chính nó
        });

        const addBtn = newContentBlock.querySelector(".add-btn");
        addBtn.addEventListener("click", function () {
            addContentBlock(newContentBlock); // Thêm một content_block mới
        });

        // Thêm newContentBlock vào sau contentBlock hiện tại
        contentBlock.parentElement.appendChild(newContentBlock);
    };

    // Gắn sự kiện cho tất cả nút "Thêm" ban đầu
    document.querySelectorAll(".add-btn").forEach((addButton) => {
        addButton.addEventListener("click", function () {
            const contentBlock = this.closest(".content_block");
            addContentBlock(contentBlock);
        });
    });

    // Gắn sự kiện "Xóa" cho các nút xóa ban đầu
    document.querySelectorAll(".delete-btn").forEach((deleteButton) => {
        deleteButton.addEventListener("click", function () {
            const contentBlock = this.closest(".content_block");
            contentBlock.remove();
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    // Xử lý sự kiện nhấn vào nút Xóa
    document.querySelectorAll(".delete-btn").forEach((btn) => {
        btn.addEventListener("click", function (e) {
            e.stopPropagation(); // Ngừng sự kiện để không kích hoạt hover
            const block = this.closest(".block");
            block.remove(); // Xóa block
        });
    });
});

