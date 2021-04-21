import { createSelector } from 'reselect'

export const getMenuState = (state: RootState): MenuState => state && state.menu
export const getDinnerMenuOptions = createSelector(getMenuState, menu => menu && menu.dinnerOptions)