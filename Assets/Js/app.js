import Alpine from 'alpinejs'

window.openModal = (id) => {
  const modal = document.getElementById(id)
  modal.showModal();
  console.log("CLICKED")
}

window.closeModal = (id) => {
  const modal = document.getElementById(id)
  modal.close();
  console.log("CLICKED")
}

window.Alpine = Alpine

Alpine.start()

