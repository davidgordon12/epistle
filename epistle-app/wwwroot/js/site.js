document.onkeydown = (e) => {
    if (e.ctrlKey && e.key === 's') {
        document.getElementById('main_form').submit();
        e.preventDefault();
    }
}

function update_search() {
    console.log("hrer");
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById("search");
    filter = input.value.toUpperCase();
    ul = document.getElementById("notes");
    li = ul.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function show_shelf() {
    document.getElementById('mini_shelf').classList.toggle('visually-hidden');
}

function show_notes() {
    document.getElementById('mini_notelist').classList.toggle('visually-hidden');
}

function dark_mode() {
    document.getElementById('textarea').classList.toggle('dark_mode');
}

function render_shelf() {
    document.getElementById('shelf_creation').classList.toggle('visually-hidden');
}

function render_push() {
    document.getElementById('push_shelf').classList.toggle('visually-hidden');
}

function render_delete() {
    document.getElementById('delete_shelf').classList.toggle('visually-hidden');
}

function fix_text() {
    setTimeout(fix, 100);
}

function fix() {
    document.getElementById('textarea').value = document.getElementById('textarea').textContent.replace("&#xD;&#xA;", "");
}