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