// Duyệt cv
function updateTrangThai(idHoSo, trangThai) {
    if (confirm(`Bạn có chắc chắn muốn${trangThai.replace("Đã", "")} CV này?`)) {
        fetch(`https://localhost:7208/api/HoSoDaNops/UpdateTrangThai?idHoSo=${idHoSo}&trangThai=${encodeURIComponent(trangThai)}`, {
            method: 'POST', 
        })
           
            .then(data => {
                if (data.Success) {
                    const statusCell = document.querySelector(`[data-id='${idHoSo}']`);
                    if (statusCell) {
                        if (trangThai === "Đã duyệt") {
                            statusCell.innerHTML = `
                            <div class="btn-approved condition d-flex">
                                <span class="m-auto">Đã duyệt</span>
                            </div>`;
                        } else if (trangThai === "Đã từ chối") {
                            statusCell.innerHTML = `
                            <div class="btn-refused condition d-flex">
                                <span class="m-auto">Đã từ chối</span>
                            </div>`;
                        }
                        alert("Cập nhật trạng thái thành công!");
                    }
                    
                } 
            })
            .catch(error => {
                console.error('Lỗi:', error);
                alert('Đã xảy ra lỗi khi cập nhật trạng thái.');
            });
    }
}

// Combobox trạng thái cv và Đếm số lượng ứng viên
document.addEventListener("DOMContentLoaded", () => {
    const filterDropdown = document.querySelector(".form-condition");
    const candidateCountElement = document.querySelector(".count-candidate"); 

   
    function countVisibleRows() {
        const rows = document.querySelectorAll(".list-cv tbody tr"); 
        const visibleRows = Array.from(rows).filter(row => row.style.display !== "none"); 
        return visibleRows.length;
    }

    filterDropdown.addEventListener("change", (event) => {
        const selectedValue = event.target.value;

        const rows = document.querySelectorAll(".page-list-cv .list-cv tbody tr");

        rows.forEach(row => {
            const statusElement = row.querySelector(".condition");
            if (statusElement) {
                const statusText = statusElement.textContent.trim();

                if (selectedValue === "1" && statusText === "Đã duyệt") {
                    row.style.display = ""; 
                } else if (selectedValue === "2" && statusText === "Đã từ chối") {
                    row.style.display = ""; 
                } else if (selectedValue === "3" && (statusText === "Duyệt" || statusText === "Từ chối")) {
                    row.style.display = ""; 
                } else if (selectedValue === "Hiển thị tất cả CV") {
                    row.style.display = "";
                } else {
                    row.style.display = "none"; 
                }
            }
        });

     
        const totalVisibleRows = countVisibleRows();
        candidateCountElement.textContent = totalVisibleRows;
    });

    const initialTotalVisibleRows = countVisibleRows();
    candidateCountElement.textContent = initialTotalVisibleRows;
});

// Tìm kiếm
document.addEventListener("DOMContentLoaded", () => {
    const searchInput = document.querySelector(".search-input"); 
    const rows = document.querySelectorAll(".list-cv tbody tr"); 
    const candidateCountElement = document.querySelector(".count-candidate"); 

    function searchAndCountCandidates() {
        const query = searchInput.value.trim().toLowerCase();
        let visibleCount = 0; 

        rows.forEach(row => {
            const columns = row.querySelectorAll("td"); 
            let matchFound = false;

            columns.forEach(column => {
                const text = column.textContent.trim().toLowerCase();
                if (text.includes(query)) {
                    matchFound = true; 
                }
            });

            
            if (matchFound) {
                row.style.display = "";
                visibleCount++; 
            } else {
                row.style.display = "none"; 
            }
        });

       
        candidateCountElement.textContent = visibleCount;
    }

    searchInput.addEventListener("input", searchAndCountCandidates);
});



