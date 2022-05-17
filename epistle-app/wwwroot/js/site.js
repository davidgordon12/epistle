document.onkeydown = (e) => {
    if (e.ctrlKey && e.key === 's') {
        document.getElementById('main_form').submit();
        e.preventDefault();
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