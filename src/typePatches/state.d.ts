declare interface MenuFormValues {
	sundayDinner: FormSelectOption
}

declare interface MenuState {
	dinnerOptions: FormSelectOption[]
}

declare interface RootState {
	menu: MenuState
}