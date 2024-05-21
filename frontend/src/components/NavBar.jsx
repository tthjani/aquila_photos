

const Navbar = () => {
  return (
    <nav className="navbar">
      <ul className="navbar-nav">
        <li className="nav-item">
          <a href="#pricing" className="nav-link">
            Pricing
          </a>
        </li>
        <li className="nav-item">
          <a href="#gallery" className="nav-link">
            Gallery
          </a>
        </li>
        <li className="nav-item">
          <a href="#cart" className="nav-link">
            Cart
          </a>
        </li>
        <li className="nav-item">
          <a href="#contact" className="nav-link">
            Contact
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Navbar;
