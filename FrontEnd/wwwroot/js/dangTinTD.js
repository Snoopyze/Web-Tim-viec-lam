﻿tinymce.init({
    selector: 'textarea',
    plugins: [
        // Core editing features
        'anchor', 'autolink', 'charmap', 'codesample', 'emoticons', 'image', 'link', 'lists', 'media', 'searchreplace', 'table', 'visualblocks', 'wordcount',
        // Your account includes a free trial of TinyMCE premium features
        // Try the most popular premium features until Dec 18, 2024:
        'checklist', 'mediaembed', 'casechange', 'export', 'formatpainter', 'pageembed', 'a11ychecker', 'tinymcespellchecker', 'permanentpen', 'powerpaste', 'advtable', 'advcode', 'editimage', 'advtemplate', 'ai', 'mentions', 'tinycomments', 'tableofcontents', 'footnotes', 'mergetags', 'autocorrect', 'typography', 'inlinecss', 'markdown',
        // Early access to document converters
        'importword', 'exportword', 'exportpdf'
    ],
    toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table mergetags | addcomment showcomments | spellcheckdialog a11ycheck typography | align lineheight | checklist numlist bullist indent outdent | emoticons charmap | removeformat',
    tinycomments_mode: 'embedded',
    tinycomments_author: 'Author name',
    mergetags_list: [
        { value: 'First.Name', title: 'First Name' },
        { value: 'Email', title: 'Email' },
    ],
    ai_request: (request, respondWith) => respondWith.string(() => Promise.reject('See docs to implement AI Assistant')),
});

//--------------------------textarea------------------------

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