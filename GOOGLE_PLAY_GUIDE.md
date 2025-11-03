# BMI Calculator - Google Play Publishing Guide

## ? Build Complete!

**App Package:** com.cubecode.bmicalculator-Signed.aab
**Location:** BmiCalculator\bin\Release\net9.0-android\publish\
**Size:** 21.53 MB
**Package Name:** com.cubecode.bmicalculator
**Version:** 1.0 (Version Code: 1)

---

## ?? Google Play Console Upload Steps

### Step 1: Go to Google Play Console
1. Visit: https://play.google.com/console
2. Sign in with your Google account
3. If you don't have a developer account, you'll need to:
   - Pay the $25 one-time registration fee
   - Complete account verification

### Step 2: Create a New App
1. Click "Create app"
2. Fill in the details:
   - **App name:** BMI Calculator
   - **Default language:** English (United States)
   - **App or game:** App
   - **Free or paid:** Free
3. Accept the declarations and click "Create app"

### Step 3: Set Up Your App
Complete the following sections in the left sidebar:

#### A. App Access
- Select "All functionality is available without special access"
- Click "Save"

#### B. Ads
- Select: "No, my app does not contain ads"
- Click "Save"

#### C. Content Rating
1. Start questionnaire
2. Select category: "Utility, Productivity, Communication, or Other"
3. Answer questions (mostly "No" for a BMI calculator)
4. Get rating and click "Apply rating"

#### D. Target Audience
1. Select age groups: 13+ (or appropriate for your app)
2. Complete Store Presence questions
3. Click "Save"

#### E. News App
- Select "No" (this is not a news app)
- Click "Save"

#### F. COVID-19 Contact Tracing and Status Apps
- Select "No"
- Click "Save"

#### G. Data Safety
1. Click "Start"
2. For a simple BMI calculator:
   - Data collection: "No, we don't collect any data"
   - Or be specific if you add analytics later
3. Complete the form and click "Save"

#### H. Government Apps
- Select "No"
- Click "Save"

#### I. Financial Features
- Select "No" (unless you add payments)
- Click "Save"

#### J. Privacy Policy
**You need a privacy policy URL!**

Simple template for BMI Calculator (host this on your website/GitHub):
```
Privacy Policy for BMI Calculator

Last updated: [Current Date]

This app does not collect, store, or share any personal information.
All BMI calculations are performed locally on your device.
No data is transmitted to external servers.

Contact: [Your Email]
```

Suggested hosting options:
- GitHub Pages (free)
- Google Sites (free)
- Your own website

---

### Step 4: Main Store Listing

#### App Details
- **App name:** BMI Calculator
- **Short description (80 chars):**
  ```
  Calculate your Body Mass Index quickly and track your health journey
  ```
  
- **Full description (4000 chars):**
  ```
  BMI Calculator helps you easily calculate your Body Mass Index (BMI) based on your height and weight. Track your health with our modern, user-friendly interface.

  ? FEATURES:
  • Quick and accurate BMI calculation
  • Easy-to-understand BMI categories
  • Clean, modern design with teal gradient theme
  • Supports metric units (kg/cm)
  • Instant results with health guidance
  • Color-coded BMI categories (Underweight, Normal, Overweight, Obesity)
  • Accessibility support
  
  ?? UNDERSTANDING YOUR BMI:
  BMI (Body Mass Index) is a measure of body fat based on height and weight. Our app provides immediate feedback and categorization based on WHO standards:
  
  • Underweight: BMI < 18.5
  • Normal Weight: BMI 18.5-24.9
  • Overweight: BMI 25-29.9
  • Obesity: BMI ? 30
  
  ?? WHO SHOULD USE THIS APP:
  Anyone interested in monitoring their health and body weight. Perfect for:
  • Health-conscious individuals
• Fitness enthusiasts
  • People on weight management programs
  • Healthcare professionals
  
  ?? DISCLAIMER:
  BMI is a screening tool and not a diagnostic of body fatness or health. Please consult with healthcare providers for personalized health advice.
  
  ?? PRIVACY:
  This app does not collect, store, or share any personal information. All calculations are performed locally on your device.
  
  Made with ?? by CubeCode
  ```

#### Graphics
You need to prepare these images:

1. **App Icon (Required)**
   - 512 x 512 pixels
   - 32-bit PNG (with alpha)
   - You already have: Resources\AppIcon\icon.jpeg
   - Convert to PNG if needed

2. **Feature Graphic (Required)**
   - 1024 x 500 pixels
   - JPG or 24-bit PNG
   - Create an attractive banner showing your app

3. **Screenshots (Minimum 2, Maximum 8)**
   - Phone: At least 2 screenshots
   - Minimum dimension: 320px
   - Maximum dimension: 3840px
   - Max aspect ratio: 2:1
   - 
   Suggested screenshots:
   - Main screen with input fields
   - Results screen showing BMI calculation
   - BMI categories information

4. **Optional but Recommended:**
   - 7-inch tablet screenshots (2)
   - 10-inch tablet screenshots (2)

#### App Category
- **App category:** Health & Fitness
- **Tags:** Add relevant tags like "BMI", "Health", "Fitness", "Calculator"

#### Contact Details
- **Email:** Your support email
- **Phone:** (Optional)
- **Website:** (Optional but recommended)

---

### Step 5: Upload Your AAB File

1. Go to **Production** ? **Releases**
2. Click "Create new release"
3. Upload your AAB file: **com.cubecode.bmicalculator-Signed.aab**
4. Release name: "1.0" (automatically filled)
5. Release notes:
   ```
   ?? Initial Release - BMI Calculator v1.0
   
   Features:
   • Calculate BMI based on weight and height
   • View BMI category and health recommendations
   • Modern, user-friendly interface
   • Color-coded results for easy understanding
   • No ads, no data collection
   ```
6. Click "Save" and then "Review release"

---

### Step 6: Countries and Pricing

1. Go to **Production** ? **Countries/regions**
2. **Add countries:**
   - Select "All countries" or pick specific ones
   - Make sure to select your target markets
3. **Pricing:** Confirm "Free"
4. Click "Apply"

---

### Step 7: Review and Submit

1. Review all sections - they should all have green checkmarks
2. Click "Send for review" in the top right
3. Wait for Google's review (typically 1-7 days)

---

## ?? After Submission

### What Happens Next:
1. **App Review:** Google reviews your app (1-7 days)
2. **Status Updates:** You'll receive emails about the status
3. **Publication:** Once approved, your app goes live
4. **First Release:** May take longer (up to 7 days)

### Monitor Your App:
- Check the dashboard for review status
- Respond to any questions from Google
- Monitor crash reports once live
- Check user reviews and ratings

---

## ?? Future Updates

When you need to update your app:

1. **Update version in BmiCalculator.csproj:**
   ```xml
   <ApplicationDisplayVersion>1.1</ApplicationDisplayVersion>
   <ApplicationVersion>2</ApplicationVersion>
   ```

2. **Rebuild the AAB:**
   ```powershell
   cd BmiCalculator
   dotnet publish -f net9.0-android -c Release /p:AndroidPackageFormat=aab
   ```

3. **Upload to Play Console:**
   - Go to Production ? Create new release
   - Upload new AAB
   - Add release notes describing changes

---

## ?? Important Reminders

1. **BACKUP YOUR KEYSTORE!**
 - File: bmicalculator.keystore
   - Password: [Your password]
   - Location: C:\Repo\Playground\CodeCube\BmiCalculator\
   - **Without this, you can NEVER update your app!**

2. **Keep Track Of:**
   - Keystore file and passwords
   - Package name: com.cubecode.bmicalculator
   - App signing key fingerprints (in Play Console)

3. **Before Launching:**
   - Test on multiple Android devices/versions
   - Check all UI elements
   - Verify calculations are accurate
   - Test on different screen sizes

---

## ?? Support

If you encounter issues:
- **Google Play Console Help:** https://support.google.com/googleplay/android-developer
- **Status page:** https://status.cloud.google.com/

---

## ? Checklist

Before submitting, make sure you have:
- [ ] Signed AAB file (com.cubecode.bmicalculator-Signed.aab)
- [ ] App icon (512x512 PNG)
- [ ] Feature graphic (1024x500)
- [ ] At least 2 screenshots
- [ ] Privacy policy URL
- [ ] App description written
- [ ] Content rating completed
- [ ] All store listing sections completed
- [ ] Keystore file backed up safely

---

**Good luck with your app launch! ??**

---

*Generated: [Current Date]*
*App Package: com.cubecode.bmicalculator-Signed.aab*
*Version: 1.0*
