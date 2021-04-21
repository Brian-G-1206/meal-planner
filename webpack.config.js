const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');

const port = process.env.PORT || 3000;

module.exports = {
	devServer: {
		host: 'localhost',
		port: port,
		historyApiFallback: true,
		open: true
	},
	devtool: 'inline-source-map',
	entry: './src/index.js',
	mode: 'development',
	module: {
		rules: [
			{
				test: /\.tsx?$/,
				use: 'ts-loader',
				exclude: /node_modules/,
			},
			{
				test: /\.(js)$/,
				exclude: /node_modules/,
				use: ['babel-loader']
			},
			{
				test: /\.css$/,
				use: [
					{
						loader: 'style-loader'
					},
					{
						loader: 'css-loader',
						options: {
							modules: true,
							sourceMap: true
						}
					}
				]
			},
			{
				test: /\.less$/,
				use: [
					{ loader: 'style-loader' },
					{ loader: 'css-loader' },
					{ loader: 'less-loader' }
				]
			},
		]
	},
	output: {
		filename: 'bundle.[hash].js'
	},
	plugins: [
		new HtmlWebpackPlugin({
			template: 'public/index.html',
			favicon: 'public/favicon.ico'
		})
	],
	resolve: {
        extensions: ['.ts', '.tsx', '.js', '.json']
    },
};