import "./App.css"; // App.css importálása
import Navbar from "./components/NavBar";
import HomeButton from "./components/HomeButton";
import AnnouncementBox from "./components/AnnouncementBox"; // AnnouncementBox komponens importálása
import CameraBox from "./components/CameraBox"; // CameraBox komponens importálása
import { useState } from "react";

function App() {
  const [showAnnouncement, setShowAnnouncement] = useState(true);
  const [showArrowDown, setShowArrowDown] = useState(true);
  const [showArrowUp, setShowArrowUp] = useState(true);

  const toggleComponent = () => {
    setShowAnnouncement(!showAnnouncement);
    setShowArrowDown(!showAnnouncement);
    setShowArrowUp(showAnnouncement)
  };


  return (
    <div>
      <Navbar />
      <HomeButton />
      <div
        className={
          showAnnouncement
            ? "announcement-container"
            : "announcement-container hidden"
        }
      >
        <AnnouncementBox />
      </div>
      <div
        className={
          !showAnnouncement ? "camera-container" : "camera-container hidden"
        }
      >
        <CameraBox />
        <div
          className={showArrowUp ? "arrow-up" : "arrow-up hidden"}
          onClick={toggleComponent}
        >
          &#8250;
        </div>
      </div>
      <div
        className={showArrowDown ? "arrow-down" : "arrow-down hidden"}
        onClick={toggleComponent}
      >
        &#8250;
      </div>
    </div>
  );
}

export default App;
