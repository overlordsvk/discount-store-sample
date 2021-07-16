import React, { Component } from 'react';

export class Shop extends Component {
  static displayName = Shop.name;

  constructor(props) {
    super(props);
    this.state = { items: [], loading: true };
  }

  componentDidMount() {
    this.getData();
  }

  static renderItemTable(items) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Id</th>
              <th>SKU</th>
              <th>Price</th>
              <th>Buy</th>
            </tr>
          </thead>
          <tbody>
            {items.map(item =>
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.sku}</td>
                <td>{item.price}</td>
                <td><button onClick={() => addItem(item)}>+</button></td>
              </tr>
            )}
          </tbody>
        </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Shop.renderItemTable(this.state.items);

    return (
      <div>
        <h1 id="tabelLabel" >Shop items</h1>
        {contents}
      </div>
    );
  }

  async getData() {
    const response = await fetch('api/shop');
    const data = await response.json();
    this.setState({ items: data, loading: false });
  }
}

function addItem(item) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(item)
    };
    fetch('api/cart', requestOptions);
}
