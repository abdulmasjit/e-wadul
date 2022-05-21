const device = {
  width: 0,
  height: 0
}
const networking = {
  connection: true,
  connectionType: null,
  noInternetModal: false
}

const authenticated = {
  dateLogin: null,
  isAuthen: false,
  accessToken: null,
  tokenType: null,
}

const dataUser = {
  name: null,
  roles: null
}

const state = {
  toggleMenu: true,
  device,
  network: networking,
  loading: false,
  authenticated,
  appActiveUser: dataUser,
  showLoading: false
}

export default state