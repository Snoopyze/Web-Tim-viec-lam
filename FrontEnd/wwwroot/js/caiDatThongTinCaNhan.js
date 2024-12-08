 // Checkbox và text cho tìm việc
 const jobSearchCheckbox = document.getElementById("toggle-job-search");
 const jobSearchText = document.getElementById("job-search-text");

 // Checkbox và text cho cho phép NTD tìm kiếm hồ sơ
 const allowNtdCheckbox = document.getElementById("toggle-allow-ntd");
 const allowNtdText = document.getElementById("allow-ntd-text");

 const text_jobSearchText = document.getElementById("text_jobSearchText")
 const text_allowNtdText = document.getElementById("text_allowNtdText")
 // Lắng nghe sự kiện 'change' cho checkbox tìm việc
 jobSearchCheckbox.addEventListener("change", function () {
   if (jobSearchCheckbox.checked) {
     jobSearchText.textContent = "Đã bật tìm việc";
     text_jobSearchText.textContent="Trạng thái Bật tìm việc sẽ tự động tắt sau 14 ngày. Nếu bạn vẫn còn nhu cầu tìm việc, hãy Bật tìm việc trở lại";
     text_jobSearchText.style.color = "Black"
   } else {
     jobSearchText.textContent = "Đang Tắt tìm việc";
     text_jobSearchText.textContent="Bật tìm việc giúp hồ sơ của bạn nổi bật hơn và được chú ý nhiều hơn trong danh sách tìm kiếm của NTD.";
     text_jobSearchText.style.color = "#a1a1a1"
   }
 });

 // Lắng nghe sự kiện 'change' cho checkbox cho phép NTD
 allowNtdCheckbox.addEventListener("change", function () {
   if (allowNtdCheckbox.checked) {
     allowNtdText.textContent = "Đã bật cho phép NTD tìm kiếm hồ sơ";
     text_allowNtdText.textContent="Khi có cơ hội việc làm phù hợp, NTD sẽ liên hệ và trao đổi với bạn qua Email và số điện thoại của bạn";
     text_allowNtdText.style.color = "Black"
   } else {
     allowNtdText.textContent = "Cho phép NTD tìm kiếm hồ sơ";
     text_allowNtdText.textContent="Khi bạn cho phép, các NTD uy tín có thể chủ động kết nối và gửi đến bạn những cơ hội việc làm hấp dẫn nhất, giúp nhân đôi hiệu quả tìm việc.";
     text_allowNtdText.style.color = "#a1a1a1"
   }
 });