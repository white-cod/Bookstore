# Bookstore Project

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![GitHub Issues](https://img.shields.io/github/issues/white-cod/Bookstore)](https://github.com/white-cod/Bookstore/issues)
[![GitHub Stars](https://img.shields.io/github/stars/white-cod/Bookstore)](https://github.com/white-cod/Bookstore/stargazers)

## Overview

The Bookstore project is a comprehensive e-commerce platform designed for book lovers. This application provides a complete solution for browsing, searching, and purchasing books online. Built with modern web technologies, it features both customer-facing storefront interfaces and administrative management capabilities.

## Features

### Customer Features
- 📚 Book catalog with filtering by genre, author, and price
- 🔍 Advanced search functionality
- 🛒 Shopping cart with persistent storage
- 🔐 User authentication (login/registration)
- 💳 Secure checkout process
- ⭐ Book ratings and reviews
- 📱 Responsive design for all devices

### Admin Features
- 📊 Dashboard with sales analytics
- 📖 Book inventory management (CRUD operations)
- 📦 Order processing system
- 👥 User management interface
- 📈 Sales reports generation
- ✉️ Email notification system

## Technology Stack

### Frontend
- **React** (v18) - Core UI framework
- **Redux** - State management
- **Tailwind CSS** - Styling framework
- **React Router** - Navigation
- **Axios** - HTTP requests

### Backend
- **Node.js** (v18+) - Runtime environment
- **Express** - Web application framework
- **MongoDB** (with Mongoose) - Database
- **JWT** - Authentication
- **Stripe API** - Payment processing

### DevOps
- **Docker** - Containerization
- **GitHub Actions** - CI/CD pipeline
- **ESLint & Prettier** - Code quality
- **Jest & React Testing Library** - Testing

## Getting Started

### Prerequisites
- Node.js v18 or higher
- MongoDB v6 or higher
- npm v9 or higher

### Installation

1. Clone the repository:
```bash
git clone https://github.com/white-cod/Bookstore.git
cd Bookstore
```

2. Install dependencies for both client and server:
```bash
cd client && npm install
cd ../server && npm install
```

3. Set up environment variables:
```bash
# Create .env file in server directory
cp server/.env.example server/.env
```

4. Configure your environment variables in `.env`:
```env
MONGO_URI=your_mongodb_connection_string
JWT_SECRET=your_jwt_secret_key
STRIPE_SECRET_KEY=your_stripe_secret_key
```

5. Start the development environment:
```bash
# From project root
npm run dev
```

The application will be available at:
- Frontend: http://localhost:3000
- Backend: http://localhost:5000

## Project Structure

```
Bookstore/
├── client/               # Frontend application
│   ├── public/           # Static assets
│   ├── src/              # React source code
│   │   ├── components/   # Reusable UI components
│   │   ├── pages/        # Application views
│   │   ├── store/        # Redux configuration
│   │   ├── utils/        # Helper functions
│   │   └── App.js        # Main application component
├── server/               # Backend application
│   ├── config/           # Configuration files
│   ├── controllers/      # Route controllers
│   ├── middleware/       # Custom middleware
│   ├── models/           # MongoDB models
│   ├── routes/           # API endpoints
│   ├── utils/            # Utility functions
│   └── server.js         # Server entry point
├── docker-compose.yml    # Docker configuration
├── .github/              # GitHub Actions workflows
└── README.md             # Project documentation
```

## API Documentation

The backend API follows RESTful principles. Below are the main endpoints:

### Books
- `GET /api/books` - Get all books
- `GET /api/books/:id` - Get single book
- `POST /api/books` - Create new book (admin)
- `PUT /api/books/:id` - Update book (admin)
- `DELETE /api/books/:id` - Delete book (admin)

### Users
- `POST /api/users` - Register new user
- `POST /api/users/auth` - Authenticate user
- `GET /api/users/profile` - Get user profile
- `PUT /api/users/profile` - Update profile

### Orders
- `POST /api/orders` - Create new order
- `GET /api/orders/myorders` - Get logged in user's orders
- `GET /api/orders/:id` - Get order by ID
- `PUT /api/orders/:id/pay` - Update order to paid

For complete API documentation, visit the [API Reference](https://github.com/white-cod/Bookstore/wiki/API-Reference).

## Testing

Run tests for both frontend and backend:

```bash
# Run frontend tests
cd client && npm test

# Run backend tests
cd server && npm test
```

Testing includes:
- Unit tests for components and utilities
- Integration tests for API endpoints
- End-to-end tests for critical user flows

## Deployment

### Docker Deployment
```bash
docker-compose up --build
```

### Manual Deployment
1. Build production frontend:
```bash
cd client && npm run build
```

2. Start production server:
```bash
cd server && npm start
```

The application is configured for deployment to:
- Heroku
- AWS Elastic Beanstalk
- Vercel (frontend) + Render (backend)

## Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a pull request

Please ensure your code follows our style guidelines and includes appropriate tests.

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/white-cod/Bookstore/blob/main/LICENSE) file for details.

## Contact

For questions or support, please contact:

Project Maintainer: white-cod  
Email: contact@bookstore.example.com  
[Project Discussion Board](https://github.com/white-cod/Bookstore/discussions)

---

**Bookstore** © 2023-present, white-cod, artem-ost. Released under the MIT License.
