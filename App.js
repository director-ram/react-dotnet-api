import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import CompanyList from "./components/CompanyList";
import { Container } from '@mui/material';

function App() {
    return (
        <Router>
            <Container maxWidth="md" className="mx-auto p-4">
                <Routes>
                    <Route path="/" element={<CompanyList />} />
                </Routes>
            </Container>
        </Router>
    );
}

export default App;
