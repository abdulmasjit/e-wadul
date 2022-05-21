const actions = {
  setToggleMenu: ({ commit }: any, toggle: boolean) => {
    commit('SET_TOGGLE_MENU', toggle)
  },
  initResize: ({ commit }: any) => {
    window.addEventListener('resize', () => {
      commit('SET_WIDTH', window.innerWidth)
      commit('SET_HEIGHT', window.innerHeight)
    })
  },
  initNetworkOn: ({ commit }: any) => {
    window.addEventListener('online', () => {
      commit('SET_CONNECTION', true)
    })
  },
  initNetworkOff: ({ commit }: any) => {
    window.addEventListener('offline', () => {
      commit('SET_CONNECTION', false)
      commit('SET_NO_INTERNET_MODAL', true)
    })
  },
  setWidth: ({ commit }: any) => {
    commit('SET_WIDTH', window.innerWidth)
  },
  setHeight: ({ commit }: any) => {
    commit('SET_HEIGHT', window.innerHeight)
  },
  destroyResize: ({ commit }: any) => {
    window.removeEventListener('resize', () => ({}))
  },
  setNoInternet: ({ commit }: any, noInternet: boolean) => {
    commit('SET_NO_INTERNET_MODAL', noInternet)

    if (noInternet) {
      commit('SET_SHOW_LOADING', false)
    }
  },
  setIsAuth: ({ commit }: any, isAuth: any) => {
    commit('SET_IS_AUTHEN', isAuth)
  },
  setDateAuth: ({ commit }: any, dateAuth: any) => {
    commit('SET_DATE_AUTHEN', dateAuth)
  },
  logoutAccount: ({ commit }: any) => {
    commit('SET_DATE_AUTHEN', null)
    commit('SET_APP_ACTIVEUSER', null)
    commit('SET_IS_AUTHEN', null)
  },
  showLoading: ({ commit }: any) => {
    commit('SET_SHOW_LOADING', true)
  },
  hideLoading: ({ commit }: any) => {
    commit('SET_SHOW_LOADING', false)
  },
  setAppActiveUser: ({ commit }: any, data: any) => {
    commit('SET_APP_ACTIVEUSER', data)
  }
}

export default actions