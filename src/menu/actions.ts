import { createAction } from "@reduxjs/toolkit"
import { FormSelectOption } from "../controls/formSelect/FormSelect"

export const SET_DINNER_OPTIONS = "@menu/SET_DINNER_OPTIONS"
export const GET_DINNER_OPTIONS = "@menu/GET_DINNER_OPTIONS"
export const SAVE_MENU = "@menu/SAVE_MENU"

export const setDinnerOptions = createAction<FormSelectOption[]>(SET_DINNER_OPTIONS)
export const getDinnerOptions = createAction(GET_DINNER_OPTIONS)
export const saveMenu = createAction<MenuFormValues>(SAVE_MENU)