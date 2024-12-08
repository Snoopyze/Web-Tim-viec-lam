//const sliderWrapper = document.querySelector('.slider__wrapper');
//const slides = Array.from(document.querySelectorAll('.slider__wrapper-inner'));
//const prevButton = document.querySelector('.control--prev');
//const nextButton = document.querySelector('.control--next');

//const firstClone = slides[0].cloneNode(true);
//const lastClone = slides[slides.length - 1].cloneNode(true);

//sliderWrapper.appendChild(firstClone);
//sliderWrapper.insertBefore(lastClone, slides[0]);

//const allSlides = document.querySelectorAll('.slider__wrapper-inner');
//const totalSlides = allSlides.length;

//let currentIndex = 1; 
//const slideWidth = slides[0].offsetWidth;

//sliderWrapper.style.transform = `translateX(-${slideWidth}px)`;


//function updateSliderPosition() {
//    sliderWrapper.style.transition = 'transform 0.5s ease-in-out';
//    sliderWrapper.style.transform = `translateX(-${currentIndex * slideWidth}px)`;
//}
//sliderWrapper.addEventListener('transitionend', () => {
//    if (currentIndex === 0) {
      
//        sliderWrapper.style.transition = 'none';
//        currentIndex = totalSlides - 2;
//        sliderWrapper.style.transform = `translateX(-${currentIndex * slideWidth}px)`;
//    } else if (currentIndex === totalSlides - 1) {
        
//        sliderWrapper.style.transition = 'none';
//        currentIndex = 1;
//        sliderWrapper.style.transform = `translateX(-${currentIndex * slideWidth}px)`;
//    }
//});
//prevButton.addEventListener('click', () => {
//    currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
//    updateSliderPosition();
//    stopAutoPlay();
//});

//nextButton.addEventListener('click', () => {
//    currentIndex = (currentIndex + 1) % totalSlides;
//    updateSliderPosition();
//    stopAutoPlay();
//});

//let autoPlay = setInterval(() => {
//    currentIndex++;
//    updateSliderPosition();
//}, 3000);

//const stopAutoPlay = () => {
//    clearInterval(autoPlay);
//    autoPlay = setInterval(() => {
//        currentIndex++;
//        updateSliderPosition();
//    }, 3000);
//};