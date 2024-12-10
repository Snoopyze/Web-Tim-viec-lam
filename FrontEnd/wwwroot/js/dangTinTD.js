
const btnDecrease = document.querySelector(".btn-decrease")
const btnIncrease = document.querySelector(".btn-increase")
const quantity = document.querySelector("#quantity")
console.log(btnDecrease);
console.log(btnIncrease);
console.log(quantity);

btnDecrease.addEventListener("click", function () {
    let currValue = parseInt(quantity.value)
    if (currValue > 1) {
        quantity.value = currValue-1;
    }

})

btnIncrease.addEventListener("click", function () {
    let currValue = parseInt(quantity.value);
    quantity.value = currValue+1;
})

//--------------------------btndecrease, btnincrease------------------------