// Dem Cv ung tuyen
fetch('https://localhost:7208/api/HoSoDaNops/DemCVUngTuyenMoi')
    .then(response => response.json()) 
    .then(data => {
        if (data.pendingCVCount !== undefined) {
            document.querySelector('.pendingCVCount').innerText = data.pendingCVCount;
        } else {
            console.error("Lỗi từ API:", data.Message);
        }
    })
    .catch(error => {
        console.error("Lỗi khi gọi API:", error);
    });

// Dem Cv da tiếp nhận

fetch('https://localhost:7208/api/HoSoDaNops/DemCVDaTiepNhan')
    .then(response => response.json())
    .then(data => {
        if (data.approvedCVCount !== undefined) {
            document.querySelector('.approvedCVCount').innerText = data.approvedCVCount;
        } else {
            console.error("Lỗi từ API:", data.Message);
        }
    })
    .catch(error => {
        console.error("Lỗi khi gọi API:", error);
    });
