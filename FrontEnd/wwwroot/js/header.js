var liElements = document.querySelectorAll(".hover");
//hover vào việc làm và hồ sơ thì đổ menu xún 
liElements.forEach(l => {
    l.onmouseenter = () => {
       dropMenu = l.querySelector('.drop-menu')
       if(dropMenu.classList.contains("hidden")){
        dropMenu.classList.remove("hidden")
       }
       l.onmouseleave = () => {
         
            dropMenu.classList.add("hidden")
           
       }
    };
});

//click vào mũi tên bên cạnh ava 
var items = document.querySelectorAll(".click-icon"); 
items.forEach(e => {
    e.querySelector(".icon").onclick =() => {
        clickDrop = e.querySelector(".click-drop")
        if(clickDrop.classList.contains("hidden")){
            clickDrop.classList.remove("hidden")
           }
        else
            clickDrop.classList.add("hidden")

    }
});