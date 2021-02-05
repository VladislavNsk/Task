(function () {
    var dropArea = document.getElementById("drop");
    document.getElementById("file").addEventListener("change", setName);

    ["dragenter", "dragover", "dragleave", "drop"].forEach(function (eventName) {
        dropArea.addEventListener(eventName, preventDefaults, false);
    });

    function preventDefaults(event) {
        event.preventDefault();
        event.stopPropagation();
    }

    ["dragenter", "dragover"].forEach(function (eventName) {
        dropArea.addEventListener(eventName, highlight, false);
    });

    ["dragleave", "drop"].forEach(function (eventName) {
        dropArea.addEventListener(eventName, unhighlight, false);
    });

    function highlight(e) {
        dropArea.classList.add("highlight");
    }
    function unhighlight(e) {
        dropArea.classList.remove("highlight");
    }

    dropArea.addEventListener("drop", handleDrop, false);

    function handleDrop(e) {
        var files = e.dataTransfer.files;
        var input = document.getElementById("file");

        if (files.length > 1 || files[0].size === 0) {
            input.value = "";
            alert("Выбирите только один файл для загрузки");
            return;
        }

        var fakeButton = document.getElementById("fake_btn");
        fakeButton.innerHTML = files[0]["name"];
        input.files = files;

        var event = new Event("change");
        input.dispatchEvent(event);
    }

    function setName(event) {
        var name = event.target.files[0].name;
        document.getElementById("Name").value = name;

        if (name.length > 30) {
            name = name.substring(0, 30) + "...";
        }

        document.getElementById("fake_btn").innerHTML = name;
    }
})();