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
  SET_TOKEN: (state: any, {
    accessToken,
    tokenType
  }: any) => {
    state.authenticated.accessToken = accessToken
    state.authenticated.tokenType = tokenType
  },
  SET_DATE_AUTHEN: (state: any, dateLogin: any) => {
    state.authenticated.dateLogin = dateLogin
  },
  SET_IS_AUTHEN: (state: any, isAuthen: any) => {
    state.authenticated.isAuthen = isAuthen
  },
  SET_SHOW_LOADING: (state: any, isLoad: boolean) => {
    state.showLoading = isLoad
  }
}

export default mutations