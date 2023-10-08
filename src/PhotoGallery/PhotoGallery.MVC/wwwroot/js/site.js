function openImageModal(e) {
    modalImage.src = e.target.getAttribute('src');

    $('#imageModal').modal('show');
}