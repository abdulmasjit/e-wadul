const device = {
  width: 0,
  height: 0
}

const authenticated = {
  dateLogin: null,
  isAuth: false,
}

const appActiveUser = null

const state = {
  toggleMenu: true,
  device,
  loading: false,
  authenticated,
  appActiveUser,
  showLoading: false
}

export default state