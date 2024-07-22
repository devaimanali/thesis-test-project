import React, { useState } from 'react';
import axios from "axios";
import PropTypes from 'prop-types';

export const Home = () => {
    const [computers, setComputers] = useState([]);
    const [newComputer, setNewComputer] = useState({
        ram: '',
        diskSpace: '',
        processor: '',
        ports: ''
    });
    const [selectedComputer, setSelectedComputer] = useState(null);
    const [error, setError] = useState(null); // State to store error message

    const handleLoadClicked = async () => {
        try {
            const results = await axios.get("/computer");
            setComputers(results.data);
            setError(null); // Clear previous errors
        } catch (error) {
            setError("Error loading data. Please try again."); // Set error message
        }
    };

    const handleAddSubmit = async (e) => {
        e.preventDefault();
        try {
            const results = await axios.post("/computer", newComputer);
            setComputers([...computers, results.data]);
            setNewComputer({
                ram: '',
                diskSpace: '',
                processor: '',
                ports: ''
            });
            setError(null); // Clear previous errors
        } catch (error) {
            setError("Error adding computer. Please try again."); // Set error message
        }
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setNewComputer({
            ...newComputer,
            [name]: value
        });
    };

    const handleRowClick = (computer) => {
        setSelectedComputer(computer);
    };

    const handleUpdateInputChange = (e) => {
        const { name, value } = e.target;
        setSelectedComputer({
            ...selectedComputer,
            [name]: value
        });
    };

    const handleUpdateSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.put(`/computer/${selectedComputer.computerID}`, selectedComputer);
            setComputers(computers.map(computer => computer.computerID === selectedComputer.computerID ? selectedComputer : computer));
            setSelectedComputer(null);
            setError(null); // Clear previous errors
        } catch (error) {
            setError("Error updating computer. Please try again."); // Set error message
        }
    };

    return (
        <div>
            <h1 id="tableLabel">Computer Catalog</h1>
            <button onClick={handleLoadClicked}>Load Data</button>

            {error && <div className="error-message">{error}</div>}

            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>RAM</th>
                        <th>Disk Space</th>
                        <th>Processor</th>
                        <th>Ports</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {computers.map((computer) => (
                        <tr key={computer.computerID}>
                            <td>{computer.ram}</td>
                            <td>{computer.diskSpace}</td>
                            <td>{computer.processor}</td>
                            <td>{computer.ports}</td>
                            <td>
                                <button onClick={() => handleRowClick(computer)}>Update</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <div>
                <h2>Add a new computer</h2>
                <form onSubmit={handleAddSubmit}>
                    <div>
                        <label>RAM:</label>
                        <input
                            name="ram"
                            value={newComputer.ram}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <label>Disk Space:</label>
                        <input
                            name="diskSpace"
                            value={newComputer.diskSpace}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <label>Processor:</label>
                        <input
                            name="processor"
                            value={newComputer.processor}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <label>Ports:</label>
                        <input
                            name="ports"
                            value={newComputer.ports}
                            onChange={handleInputChange}
                        />
                    </div>
                    <div>
                        <button type="submit">Add</button>
                    </div>
                </form>
            </div>

            {selectedComputer && (
                <div>
                    <h2>Update Computer</h2>
                    <form onSubmit={handleUpdateSubmit}>
                        <div>
                            <label>RAM:</label>
                            <input
                                name="ram"
                                value={selectedComputer.ram}
                                onChange={handleUpdateInputChange}
                            />
                        </div>
                        <div>
                            <label>Disk Space:</label>
                            <input
                                name="diskSpace"
                                value={selectedComputer.diskSpace}
                                onChange={handleUpdateInputChange}
                            />
                        </div>
                        <div>
                            <label>Processor:</label>
                            <input
                                name="processor"
                                value={selectedComputer.processor}
                                onChange={handleUpdateInputChange}
                            />
                        </div>
                        <div>
                            <label>Ports:</label>
                            <input
                                name="ports"
                                value={selectedComputer.ports}
                                onChange={handleUpdateInputChange}
                            />
                        </div>
                        <div>
                            <button type="submit">Update</button>
                        </div>
                    </form>
                </div>
            )}
        </div>
    );
};

Home.propTypes = {
    computers: PropTypes.array,
    newComputer: PropTypes.object,
    selectedComputer: PropTypes.object,
    handleLoadClicked: PropTypes.func,
    handleAddSubmit: PropTypes.func,
    handleInputChange: PropTypes.func,
    handleRowClick: PropTypes.func,
    handleUpdateInputChange: PropTypes.func,
    handleUpdateSubmit: PropTypes.func,
    setComputers: PropTypes.func,
    setNewComputer: PropTypes.func,
    setSelectedComputer: PropTypes.func
};
