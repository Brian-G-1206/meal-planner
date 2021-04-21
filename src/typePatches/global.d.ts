// for redux devtools extension
declare interface Window {
    __REDUX_DEVTOOLS_EXTENSION__?(): (args?: any) => any
    __PRELOADED_STATE__: RootState
    shallow: Function
}