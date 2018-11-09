var simplemde = new SimpleMDE({
    element: $("#markdown")[0],
    placeholder: "Text",
    status: false,
    toolbar: ["bold", "italic", "heading", "|", "quote", "ordered-list",
        "unordered-list", "|", "code", "link", "image", "|", "preview",
        "side-by-side", "fullscreen"],


});