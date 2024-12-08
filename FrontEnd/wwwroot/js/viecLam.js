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

var itemsPerPageForPaginationContainer = 6;
// Hàm khởi tạo phân trang
function createPagination(itemsSelector, prevSelector, nextSelector, indicatorSelector, itemsPerPage) {
  var items = document.querySelectorAll(itemsSelector);
  var prevButton = document.querySelector(prevSelector);
  var nextButton = document.querySelector(nextSelector);
  var pageIndicator = document.querySelector(indicatorSelector);

  var currentPage = 1;
  var totalPages = Math.ceil(items.length / itemsPerPage);

  // Cập nhật hiển thị phân trang
  function updatePagination() {
    items.forEach((item, index) => {
      if (index >= (currentPage - 1) * itemsPerPage && index < currentPage * itemsPerPage) {
        item.classList.remove('hidden');
      } else {
        item.classList.add('hidden');
      }
    });

    // Cập nhật chỉ báo trang và trạng thái nút
    pageIndicator.textContent = `${currentPage}/${totalPages}`;
    prevButton.disabled = currentPage === 1;
    nextButton.disabled = currentPage === totalPages;
  }

  // Sự kiện nút "Previous"
  prevButton.addEventListener('click', () => {
    if (currentPage > 1) {
      currentPage--;
      updatePagination();
    }
  });

  // Sự kiện nút "Next"
  nextButton.addEventListener('click', () => {
    if (currentPage < totalPages) {
      currentPage++;
      updatePagination();
    }
  });

  // Khởi tạo phân trang
  updatePagination();
}

createPagination('.item-list li', 
    '#prev.btn-nav', 
    '#next.btn-nav', 
    '#page-indicator', 
    6
)

//ẨN HIỆN SLIDE
var items = document.querySelectorAll('.item-list li');
items.forEach(i => {
  i.onmouseenter =()=>{
    hiddenSlide()
  }

  i.onmouseleave =()=> {
    showSlide()
  }
}
)

function hiddenSlide(){
  var slide = document.querySelector('.slide')
  var category = document.querySelector('.header-content__detail-job')
  slide.classList.add("hidden")
  category.classList.remove("hidden")
}

function showSlide(){
  var slide = document.querySelector('.slide')
  var category = document.querySelector('.header-content__detail-job')
  slide.classList.remove("hidden")
  category.classList.add("hidden")

}

// XỬ LÝ SK DUWOIS PHẦN MAIN
//trượt thanh lọc
const smartList = document.querySelector('.box-smart-list-location');
const prevButton = document.querySelector('.prev-location');
const nextButton = document.querySelector('.next-location');
console.log(nextButton)
console.log(smartList.scrollLeft)


prevButton.addEventListener('click', () => {
  smartList.scrollBy({ left: -600, behavior: 'smooth' });
  console.log(prevButton)
});

nextButton.addEventListener('click', () => {
  smartList.scrollBy({ left: 600, behavior: 'smooth' });
  console.log(nextButton)
  console.log(smartList.scrollLeft)

});


//click vao item loc

var boxSmartItems = document.querySelectorAll('.box-smart-item')

boxSmartItems.forEach(i => {
  i.onclick =()=>{
    checked = i.classList.contains('active')
    if(checked){
      i.classList.remove('active')
    }else 
      i.classList.add('active') 
  }
  
})

//PHÂN TRANHG
// Hàm khởi tạo phân trang
function createPagination(itemsSelector, prevSelector, nextSelector, indicatorSelector, itemsPerPage) {
  var items = document.querySelectorAll(itemsSelector);
  var prevButton = document.querySelector(prevSelector);
  var nextButton = document.querySelector(nextSelector);
  var pageIndicator = document.querySelector(indicatorSelector);

  var currentPage = 1;
  var totalPages = Math.ceil(items.length / itemsPerPage);

  // Cập nhật hiển thị phân trang
  function updatePagination() {
    items.forEach((item, index) => {
      if (index >= (currentPage - 1) * itemsPerPage && index < currentPage * itemsPerPage) {
        item.classList.remove('hidden');
      } else {
        item.classList.add('hidden');
      }
    });

    // Cập nhật chỉ báo trang và trạng thái nút
    pageIndicator.textContent = `${currentPage}/${totalPages}`;
    prevButton.disabled = currentPage === 1;
    nextButton.disabled = currentPage === totalPages;
  }

  // Sự kiện nút "Previous"
  prevButton.addEventListener('click', () => {
    if (currentPage > 1) {
      currentPage--;
      updatePagination();
    }
  });

  // Sự kiện nút "Next"
  nextButton.addEventListener('click', () => {
    if (currentPage < totalPages) {
      currentPage++;
      console.log(items)
      updatePagination();
    }
  });

  // Khởi tạo phân trang
  updatePagination();
}

createPagination('.feature-job-item', 
    '.feature-job-page .btn-feature-jobs-pre', 
    '.feature-job-page .btn-feature-jobs-next',
     '.feature-job-page__text',
    15
)

