
var scrollContainer = document.querySelector(".scroll-js");
scrollContainer.onscroll = () => {
  const currentScrollTop = scrollContainer.scrollTop; 
  var headerLogo = document.querySelector('.hover-job-detail__header');
  var headerTitle = document.querySelector('.title-scroll');

  if (currentScrollTop === 0) { 
    headerLogo.classList.remove("hidden");
    headerTitle.classList.add("hidden");
  } else { 
    headerLogo.classList.add("hidden");
    headerTitle.classList.remove("hidden");
  }
};
