import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        this.state = { procedures: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
        this.populateProcedureData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    static renderProcedure(procedures) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>cliTipoClienteID</th>
                        <th>cliDescripcionTipo</th>
                    </tr>
                </thead>
                <tbody>
                    {procedures.map(procedure =>
                        <tr key={procedure.cliTipoClienteID}>
                            <td>{procedure.cliTipoClienteID}</td>
                            <td>{procedure.cliDescripcionTipo}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderForecastsTable(this.state.forecasts);
        let contents2 = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderProcedure(this.state.procedures);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
                <h1 id="tabelLabel" >Procedure</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents2}
            </div>

        );
    }

    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
    async populateProcedureData() {
        const response = await fetch('api/dspclientetiporesponses/procedure');
        const data = await response.json();
        this.setState({ procedures: data, loading: false });
    }
}
