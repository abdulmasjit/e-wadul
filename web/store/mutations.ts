const mutations = {
  SET_TOGGLE_MENU: (state: any, toggle: boolean) => {
    state.toggleMenu = toggle
  },
  SET_WIDTH: (state: any, width: number) => {
    state.device.width = width
    if (state.device.width < 1024) {
      state.toggleMenu = false
    }
  },
  SET_HEIGHT: (state: any, height: number) => {
    state.device.height = height
  },
  SET_CONNECTION: (state: any, isActive: Boolean) => {
    state.network.connection = isActive
  },
  SET_CONNECTION_TYPE: (state: any, connectionType: string) => {
    state.network.connectionType = connectionType
  },
  SET_NO_INTERNET_MODAL: (state: any, noInternet: boolean) => {
    state.network.noInternetModal = noInternet
  },
  SET_DATE_AUTHEN: (state: any, dateLogin: any) => {
    state.authenticated.dateLogin = dateLogin
  },
  SET_IS_AUTHEN: (state: any, isAuth: any) => {
    state.authenticated.isAuth = isAuth
  },
  SET_SHOW_LOADING: (state: any, isLoad: boolean) => {
    state.showLoading = isLoad
  },
  SET_APP_ACTIVEUSER: (state: any, data: any) => {
    state.appActiveUser = data
  }
}

export default mutations