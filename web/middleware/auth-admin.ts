import moment from 'moment'

export default (context: any) => {
  // console.log('any authicanted-context', context)
  const checkDateExpired = () => {
    if (context.store.state.authenticated.dateLogin && context.store.state.appActiveUser.token) {
      const dateLogin = moment(context.store.state.authenticated.dateLogin)
      const now = moment()

      const checkHours = moment.duration(now.diff(dateLogin)).asHours()

      if (checkHours <= 2) {
        return true
      }
    }
    context.store.dispatch('logoutAccount')

    return false
  }
  if (!context.store.state.authenticated.isAuth) {
    context.redirect({
      name: 'login'
    })
  }
  if (checkDateExpired() === false) {
    context.store.dispatch('logoutAccount')
    context.redirect({
      name: 'login'
    })
  }
}