document.getElementById("search-text").addEventListener("keyup", function () {
    var phrase = document.getElementById("search-text");
    var table = document.getElementById("info-table");
    var regPhrase = new RegExp(phrase.value, "i");
    var flag;

    for (var i = 1; i < table.rows.length; i++) {
        flag = false;
        for (var j = table.rows[i].cells.length - 1; j >= 0; j--) {
            flag = regPhrase.test(table.rows[i].cells[j].innerHTML);
        }

        if (flag) {
            table.rows[i].style.display = "";
        } else {
            table.rows[i].style.display = "none";
        }
    }
});

(function () {
    var headers = document.querySelectorAll("th");

    [].forEach.call(headers, function (header, index) {

        if (index === 4) {
            return;
        }

        console.log(header);
        header.addEventListener("click", function () {
            sort(index, header.getAttribute("data-type"));
        });

        header.addEventListener("mouseover", function () {
            header.style.cursor = "pointer";
        });
    });
})();

(function () {
    var tableBody = document.getElementById("info-table").querySelector("tbody");
    var rowsColl = tableBody.querySelectorAll("tr");
    var rows = Array.from(rowsColl);

    rows.forEach(function (el) {
        var name = el.querySelectorAll("td")[0].innerHTML.trim();

        if (name.length > 30) {
            el.querySelectorAll("td")[0].innerHTML = name.substring(0, 30) + "...";
        }
    });
})();

function sort(index, type) {
    console.log(type);
    var table = document.querySelector("table");
    var tableBody = table.querySelector("tbody");
    var rowsColl = [].slice.call(tableBody.rows);

    var compare = function (a, b) {
        var cellA = a.querySelectorAll("td")[index].innerHTML;
        var cellB = b.querySelectorAll("td")[index].innerHTML;

        switch (type) {
            case "date":
                var dateA = cellA.split(".").reverse();
                var dateB = cellB.split(".").reverse();
                return new Date(dateA[0], dateA[1], dateA[2]) - new Date(dateB[0], dateB[1], dateB[2]);
            default:
                return cellA.toLowerCase().localeCompare(cellB.toLowerCase());
        }
    }

    rowsColl.sort(compare);
    table.removeChild(tableBody);

    for (var i = 0; i < rowsColl.length; i++) {
        tableBody.appendChild(rowsColl[i]);
    }

    table.appendChild(tableBody);
}