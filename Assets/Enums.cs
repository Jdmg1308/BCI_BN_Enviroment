namespace Interaxon.Libmuse
{
    // This file contains automatically updated code from libmuse djinni enums

    public enum MuseModel : int
    {
        Unknown = -1,
        /** First model of Muse, Muse 2014 */
        MU_01,
        /** Muse 2016 with Bluetooth Low Energy support. */
        MU_02,
        /** Muse2 2018 adding PPG sensor, Accelerometer and Gyroscope. */
        MU_03,
        /** MuseS 2019 softband (MS-01). */
        MU_04,
        /** MuseS 2021 softband refresh (MS-02). */
        MU_05,
        /** Muse2 2024 with USB-C connector. */
        MU_06,
        /** MuseS 2025 softband with USB-C, Bluetooth 5.3, improved EEG and Optics (MS-03). */
        MS_03
    }

    public enum ConnectionState : int
    {
        /** Initial state */
        UNKNOWN,
        /** This state is set if the connection was correctly established. */
        CONNECTED,
        /** This state is set while trying to establish a connection. */
        CONNECTING,
        /**
         * This state is set in case of an unsuccessful connection operation
         * or after execution of disconnect method.
         */
        DISCONNECTED,
        /**
         * This state is set when the connection succeeded but the headband's
         * firmware is out of date -- if this occurs, you should instruct your users
         * to use the %Muse app to upgrade their firmware.
         */
        NEEDS_UPDATE,
        /**
         * This state is set when the connection succeeded but the headband's
         * license is invalid.
         */
        NEEDS_LICENSE
    }

    public enum MuseDataPacketType : int
    {
        /**
         * 3-axis accelerometer data packet
         * An Accelerometer packet provides 3 pieces of data.
         * \sa
         * \li \classlink{Accelerometer} for mapping details.
         */
        ACCELEROMETER,
        /**
         * 3-axis gyro data packet
         * A Gyro packet provides 3 pieces of data.
         * \sa
         * \li \classlink{Gyro} for mapping details.
         */
        GYRO,
        /**
         * Specifies raw EEG samples.
         *
         * Values in this packet correspond to EEG data read from the different
         * sensor locations on the headband. The accessors in the Eeg enum define
         * the mapping from packet values to sensor locations.
         * The units of EEG values are microvolts.
         *
         * The size of the data is unspecified, but it is large enough to hold all
         * the EEG channels emitted by the current preset.
         *
         * In the future new %Muse Presets may be added, which will have extra
         * values.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        EEG,
        /**
         * Packet stands in for n dropped samples of the accelerometer type.
         * Size of the values array for this packet is always 1.
         *
         * \deprecated This is never emitted in an actual Muse session; instead,
         * NaN-filled packets of the basic type (EEG or ACCELEROMETER) are emitted
         * to stand in for dropped packets. This can only appear when reading
         * Muse files written with older versions of the library.
         */
        DROPPED_ACCELEROMETER,
        /**
         * Packet stands in for n dropped samples of the eeg type.
         * Size of the values array for this packet is always 1.
         *
         * \deprecated This is never emitted in an actual Muse session; instead,
         * NaN-filled packets of the basic type (EEG or ACCELEROMETER) are emitted
         * to stand in for dropped packets. This can only appear when reading
         * Muse files written with older versions of the library.
         */
        DROPPED_EEG,
        /**
         * Packet contains information about signal quantization.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         *
         * Each index in this packet corresponds to the same index in an EEG packet.
         * Quantization occurs when there is a particularly noisy signal, which
         * generally happens when there is not a good contact between the headband
         * and the skin.
         *
         * Higher numbers are worse; 1 is no quantization, and 16 is maximum
         * quantization.
         *
         * These values are used under the hood by the library and by %Muse Elements
         * in reconstructing the EEG signal and contributing to an overall measure
         * of noise; it is extremely unlikely that you will be interested in them.
         * For measuring noise, it is recommended to instead use the more useful
         * computed values like 'headband_on' or 'hsi'.
         *
         * Each quantization packet applies to the next 16 EEG packets.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        QUANTIZATION,
        /**
         * %Muse headband battery data packet.
         * This packet provides 3 pieces of data.
         * \sa
         * \li \classlink{Battery} for mapping details.
         */
        BATTERY,
        /**
         * Packet contains raw data from %Muse DRL and REF sensors.
         * This packet provides 2 pieces of data.  The units of both values are in microvolts.
         * \sa
         * \li \classlink{DrlRef} for mapping details.
         */
        DRL_REF,
        /**
         * EEG derived value.
         * Absolute alpha band powers for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        ALPHA_ABSOLUTE,
        /**
         * EEG derived value.
         * Absolute beta band powers for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        BETA_ABSOLUTE,
        /**
         * EEG derived value.
         * Absolute delta band powers for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        DELTA_ABSOLUTE,
        /**
         * EEG derived value.
         * Absolute theta band powers for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        THETA_ABSOLUTE,
        /**
         * EEG derived value.
         * Absolute gamma band powers for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        GAMMA_ABSOLUTE,
        /**
         * EEG derived value.
         * Relative alpha band powers for each channel.
         * Values in this packet are in range [0; 1].
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        ALPHA_RELATIVE,
        /**
         * EEG derived value.
         * Relative beta band powers for each channel.
         * Values in this packet are in range [0; 1].
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        BETA_RELATIVE,
        /**
         * EEG derived value.
         * Relative delta band powers for each channel.
         * Values in this packet are in range [0; 1].
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        DELTA_RELATIVE,
        /**
         * EEG derived value.
         * Relative band powers for each channel.
         * Values in this packet are in range [0; 1].
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        THETA_RELATIVE,
        /**
         * EEG derived value.
         * Relative band powers for each channel.
         * Values in this packet are in range [0; 1].
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        GAMMA_RELATIVE,
        /**
         * EEG derived value.
         * Alpha band power scores for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        ALPHA_SCORE,
        /**
         * EEG derived value.
         * Beta band power scores for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        BETA_SCORE,
        /**
         * EEG derived value.
         * Delta band power scores for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        DELTA_SCORE,
        /**
         * EEG derived value.
         * Theta band power scores for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        THETA_SCORE,
        /**
         * EEG derived value.
         * Gamma band power scores for each channel.
         * This packet contains the same amount of data as an
         * EEG packet and has the same channel mapping.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        GAMMA_SCORE,
        /**
         * EEG derived value.
         * Is Good indicates whether or not the last 1 second of raw EEG data on each
         * channel was good or not. Eye blinks or muscle movement can interfere
         * with EEG data and cause Is Good to report that the data is not good.
         * This is emitted every 1/10 of a second to represent the rolling window of the
         * last second of EEG data. This is only useful for real time EEG analysis.
         * This packet only contains 4 values for the 4 sensors on the headband,
         * there is no support for the auxillary channels.
         *
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        IS_GOOD,
        /**
         * EEG derived value.
         * HSI values represent the fit of the headband. (known as headband status indicator).
         * This value is not emitted by the LibMuse SDK.
         */
        HSI,
        /**
         * EEG derived value.
         * HSI precision values represent the fit of the headband.
         * This packet contains 4 values corresponding to
         * \enumlink{Eeg,EEG1,IXNEegEEG1},
         * \enumlink{Eeg,EEG2,IXNEegEEG2},
         * \enumlink{Eeg,EEG3,IXNEegEEG3} and
         * \enumlink{Eeg,EEG4,IXNEegEEG4}.
         * There are no
         * \enumlink{MuseDataPacketType,HSI_PRECISION,IXNMuseDataPacketTypeHsiPrecision}
         * values for the auxillary channels.<br>
         *
         * Each channel represents the fit at that location.
         * A value of \c 1 represents a good fit, \c 2 represents a mediocre fit,
         * and a value or \c 4 represents a poor fit.
         *
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        HSI_PRECISION,
        /**
         * Artifacts packet type will be sent.
         *
         * Note that this will result in your listener receiving
         * \classlink{MuseArtifactPacket}.
         * We never emit a \classlink{MuseDataPacket} with
         * \enumlink{MuseDataPacketType,ARTIFACTS,IXNMuseDataPacketTypeArtifacts};
         * this is only here for use in register / unregister methods.
         */
        ARTIFACTS,
        /**
         * 3-axis magnetometer data packet
         * A Magnetometer packet provides 3 pieces of data.
         * \sa
         * \li \classlink{Magnetometer} for mapping details.
         */
        MAGNETOMETER,
        /**
         * Pressure packet provides both a raw and averaged ambient pressure value.
         * \sa
         * \li \classlink{Pressure} for mapping details.
         */
        PRESSURE,
        /** Temperature packet provides ambient temperature value. */
        TEMPERATURE,
        /**
         * UltraViolet packet provides both UVA and
         * UVB index value and the average of the 2.
         * \sa
         * \li \classlink{UltraViolet} for mapping details.
         */
        ULTRA_VIOLET,
        /**
         * EEG derived value.
         * Notch filtered EEG is the raw EEG passed through a band stop filter
         * to remove frequencies between 45 and 65 Hz inclusive.
         * This packet contains 4 values corresponding to
         * \enumlink{Eeg,EEG1,IXNEegEEG1},
         * \enumlink{Eeg,EEG2,IXNEegEEG2},
         * \enumlink{Eeg,EEG3,IXNEegEEG3} and
         * \enumlink{Eeg,EEG4,IXNEegEEG4}.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         */
        NOTCH_FILTERED_EEG,
        /**
         * EEG derived value.
         * Signal variance for raw EEG values.
         * Variance is the numerical value that measures how widely a set of numbers
         * within the interval are spread out from the average value.
         * This packet contains the variance value of raw EEG over the last second.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         * \li https://en.wikipedia.org/wiki/Variance#Discrete_random_variable
         */
        VARIANCE_EEG,
        /**
         * EEG derived value.
         * Signal variance for notch filtered EEG.
         * Variance is the numerical value that measures how widely a set of numbers
         * within the interval are spread out from the average value.
         * This packet contains the variance value of notch filtered EEG over the last second.
         * \sa
         * \li \classlink{Eeg} for mapping details.
         * \li https://en.wikipedia.org/wiki/Variance#Discrete_random_variable
         */
        VARIANCE_NOTCH_FILTERED_EEG,
        /**
         * Specifies PPG samples.
         *
         * Values in this packet correspond to PPG data read from supported
         * hardware. The accessors in the Ppg enum define
         * the mapping from packet data to 3 different values Ambient, IR, and RED.
         * The units of PPG values are arbitrary.
         *
         * \sa
         * \li \classlink{Ppg} for mapping details.
         */
        PPG,
        /**
         * PPG derived value.
         *
         * \sa
         * \li \classlink{Ppg} for mapping details.
         */
        IS_PPG_GOOD,
        /**
         * PPG derived value.
         *
         * \sa
         * \li \classlink{Ppg} for mapping details.
         */
        IS_HEART_GOOD,
        /**
         * Provides temperature values from the thermistor that is in contact 
         * with the user's skin.
         */
        THERMISTOR,
        /** Thermistor derived value. */
        IS_THERMISTOR_GOOD,
        /** Thermistor derived value. */
        AVG_BODY_TEMPERATURE,
        /**
         * Specifies a cloud computed value.
         *
         * Values in this packet have been computed on the cloud remotely.
         * This packet type allows the libmuse library to expose new packet type
         * that has been generated remotely on the cloud.
         *
         */
        CLOUD_COMPUTED,
        /**
         * Specifies OPTICS samples.
         *
         * Values in this packet correspond to optics data read from supported
         * hardware. The accessors in the Optics enum define
         * the mapping from packet data to 16 different values.
         * The units of OPTICS values are microamps.
         *
         * \sa
         * \li \classlink{Optics} for mapping details.
         */
        OPTICS
    }

    public enum MusePreset : int
    {
        /**
         * 4 CH EEG, 10 bit @ 220 Hz, compression ON, no accelerometer, no battery
         * data, no error data, no DRL/REF data.
         * <br>
         *
         * Availability: \muse2014 only
         */
        PRESET_10,
        /**
         * 4 CH EEG, 10 bit @ 220 Hz, compression ON, 50 Hz accelerometer data,
         * 0.1 Hz battery data, no error data, no DRL/REF data
         * <br>
         *
         * Availability: \muse2014 only
         */
        PRESET_12,
        /**
         * 4 CH EEG, 10 bit @ 220 Hz, compression ON, 50 Hz accelerometer data,
         * 0.1 Hz battery data, real-time error data, 10 bit @ 10 Hz DRL/REF data
         * <br>
         *
         * This is the default for \muse2014.
         * <br>
         *
         * Availability: \muse2014 only
         */
        PRESET_14,
        /**
         * 5 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF.
         * <br>
         *
         * Availability: \muse2016, \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_20,
        /**
         * 4 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF.
         * <br>
         *
         * This is the default for \muse2016, \muse2018, \muse2019, \muse2021, \muse2024.
         * <br>
         *
         * Availability: \muse2016, \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_21,
        /**
         * 4 CH EEG, 12 bit @ 256 Hz, 0.1 Hz battery,
         * 32 Hz DRL/REF.
         * <br>
         *
         * Availability: \muse2016, \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_22,
        /**
         * 5 CH EEG, 12 bit @ 256 Hz, 0.1 Hz battery,
         * 32 Hz DRL/REF.
         * <br>
         *
         * Availability: \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_23,
        /**
         * 6 CH EEG, 16 bit @ 500 Hz, 50 Hz accelerometer, 0.1 Hz battery,
         * compression OFF, notch filter OFF, no error data, no DRL/REF data
         * <br>
         *
         * Research preset:<br>
         * Only the following data packets are generated with this preset:
         * \enumlink{MuseDataPacketType,EEG,IXNMuseDataPacketTypeEeg},
         * \enumlink{MuseDataPacketType,ACCELEROMETER,IXNMuseDataPacketTypeAccelerometer},
         * \enumlink{MuseDataPacketType,BATTERY,IXNMuseDataPacketTypeBattery}
         * <br>
         * Artifacts are not generated with this preset.<br>
         *
         * Availability: \muse2014 only
         */
        PRESET_AB,
        /**
         * 4 CH EEG, 16 bit @ 500 Hz, 50 Hz accelerometer, 0.1 Hz battery,
         * compression OFF, notch filter OFF, no error data, no DRL/REF data
         * <br>
         *
         * Research preset:<br>
         * Only the following data packets are generated with this preset:
         * \enumlink{MuseDataPacketType,EEG,IXNMuseDataPacketTypeEeg},
         * \enumlink{MuseDataPacketType,ACCELEROMETER,IXNMuseDataPacketTypeAccelerometer},
         * \enumlink{MuseDataPacketType,BATTERY,IXNMuseDataPacketTypeBattery}
         * <br>
         * Artifacts are not generated with this preset.<br>
         *
         * Availability: \muse2014 only
         */
        PRESET_AD,
        /**
         * 4 CH EEG, 12 bit @ 256 Hz, 0.1 Hz battery,
         * 32 Hz DRL/REF, 52 Hz Acc, Gyro and Magnetometer,
         * 0.1 Hz for UV and Pressure.
         * <br>
         *
         * Availability: glasses only
         */
        PRESET_31,
        /**
         * No EEG data, only other sensors.
         * 32 Hz DRL/REF, 52 Hz Acc, Gyro and Magnetometer,
         * 0.1 Hz for battery, UV and Pressure.
         * <br>
         *
         * Availability: glasses only
         */
        PRESET_32,
        /**
         * 5 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz
         * <br>
         *
         * Availability: \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_50,
        /**
         * 4 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz
         * <br>
         *
         * Availability: \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_51,
        /**
         * 4 CH EEG, 12 bit @ 256 Hz, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz
         * <br>
         *
         * Availability: \muse2018, \muse2019, \muse2021, \muse2024
         */
        PRESET_52,
        /**
         * 6 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz
         * <br>
         *
         * Availability: \muse2019, \muse2021, \muse2024
         */
        PRESET_53,
        /**
         * 6 CH EEG, 12 bit @ 128 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 16 Hz DRL/REF
         * <br>
         *
         * Availability: \muse2021
         */
        PRESET_54,
        /**
         * 4 CH EEG, 12 bit @ 128 Hz, 0.1 Hz battery,
         * 16 Hz DRL/REF, PPG @ 64 Hz
         * <br>
         *
         * Availability: \muse2021
         */
        PRESET_55,
        /**
         * 5 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz, THERMISTOR @ 16 Hz
         * <br>
         *
         * Availability: \muse2019, \muse2021
         */
        PRESET_60,
        /**
         * 4 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz, THERMISTOR @ 16 Hz
         * <br>
         *
         * Availability: \muse2019, \muse2021
         */
        PRESET_61,
        /**
         * 6 CH EEG, 12 bit @ 256 Hz, 52 Hz accelerometer/gyro, 0.1 Hz battery,
         * 32 Hz DRL/REF, PPG @ 64 Hz, THERMISTOR @ 16 Hz
         * <br>
         *
         * Availability: \muse2019, \muse2021
         */
        PRESET_63,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1021,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 1 Hz battery,
         * 32 Hz DRL/REF
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1022,
        /**
         * Battery only @ 5 Hz
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1023,
        /**
         * 52 Hz accelerometer/gyro
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1024,
        /**
         * 16 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1025,
        /**
         * 16 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1026,
        /**
         * 8 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1027,
        /**
         * 8 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1028,
        /**
         * 4 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1029,
        /**
         * 4 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_102A,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 16 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1031,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 16 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1032,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 8 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1033,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 8 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1034,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 4 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1035,
        /**
         * 4 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 4 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1036,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 16 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1041,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 16 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1042,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 8 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1043,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 8 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1044,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 4 CH Optics @ 64 Hz, low power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1045,
        /**
         * 8 CH EEG, 14 bit @ 256 Hz, 52 Hz accelerometer/gyro, 1 Hz battery,
         * 32 Hz DRL/REF, 4 CH Optics @ 64 Hz, high power
         * <br>
         * 
         * Availability: \muse2025
         */
        PRESET_1046
    }

    public enum NotchFrequency : int
    {
        /** The notch filter is not available on some hardware versions. */
        NOTCH_NONE,
        /**
         * 50 Hz frequency is used in most parts of the world:
         * Europe, Russia, Africa
         */
        NOTCH_50HZ,
        /**
         * 60 Hz frequency is used in North America and Asia.
         * This is the default setting.
         */
        NOTCH_60HZ
    }

    public enum Severity : int
    {
        /**
         * Verbose logs. These provide lots of details that are probably irrelevant
         * except for tracing or debugging problems with the headband or library.
         */
        SEV_VERBOSE,
        /**
         * Informational logs. These messages are sent when significant but expected
         * events happen (e.g. a connection started or was completed successfully.)
         */
        SEV_INFO,
        /**
         * Warning logs. These messages indicate that something out of the ordinary
         * but recoverable happened (e.g. a connection attempt failed but will be
         * retried automatically.)
         */
        SEV_WARN,
        /**
         * %Error logs. These messages indicate that something has gone wrong -- for
         * instance, a connection terminated unexpectedly or a corrupted packet was
         * received.
         */
        SEV_ERROR,
        /**
         * Fatal logs. These are sent when the library is in a completely
         * unrecoverable state from which the only reasonable outcome is termination
         * of the running process. The process will be aborted as soon as the log
         * handler returns.
         */
        SEV_FATAL,
        /**
         * Debug-only logs. These are only interesting to developers trying to track
         * down problems in the library.
         */
        SEV_DEBUG
    }

    public enum ErrorType : int
    {
        /**
         * A generic failure occurred without any further information. Retrying the
         * operation is unlikely to result in success.
         */
        FAILURE,
        /** Some timeout was exceeded; the operation might succeed if retried. */
        TIMEOUT,
        /**
         * Some resource (queue space, memory, bandwidth) was exhausted. Retry with
         * backoff.
         */
        OVERLOADED,
        /** Something was tried that isn't implemented. */
        UNIMPLEMENTED
    }

    public enum ResultLevel : int
    {
        /** default */
        R_NONE,
        /** success */
        R_SUCCESS,
        /** info */
        R_INFO,
        /** warn */
        R_WARN,
        /** error */
        R_ERROR,
        /** debug */
        R_DEBUG
    }

    public enum Eeg : int
    {
        /** Left ear */
        EEG1,
        /** Left forehead */
        EEG2,
        /** Right forehead */
        EEG3,
        /** Right ear */
        EEG4,
        /** Left auxiliary (maps to AUX1 on \muse2025). */
        AUX_LEFT,
        /** Right auxiliary (maps to AUX2 on \muse2025). */
        AUX_RIGHT,
        /** Auxiliary input 1 on \muse2025. */
        AUX1,
        /** Auxiliary input 2 on \muse2025. */
        AUX2,
        /** Auxiliary input 3 on \muse2025 */
        AUX3,
        /** Auxiliary input 4 on \muse2025 */
        AUX4
    }

    public enum Gyro : int
    {
        /**
         * Rotation about the X axis in degrees per second.
         * Rotation about the X axis corresponds to tilting the head side to side.
         * Positive values increase when tilting to the right.  This is also known as roll.<br>
         */
        X,
        /**
         * Rotation about the Y axis in degrees per second.
         * Rotation about the Y axis corresponds to tilting the head up and down.
         * Positive values increase when looking up.  This is also known as pitch.<br>
         */
        Y,
        /**
         * Rotation about the Z axis in degrees per second.
         * Rotation about the Z axis corresponds to looking left and right.
         * Positive values increase when looking to the right.  This is also known as yaw.<br>
         */
        Z
    }

    public enum Accelerometer : int
    {
        /**
         * Orientation of the X axis relative to gravity in g.
         * Values along the X axis increase as the head tilts down.
         * Negative values indicate a tilt up.<br>
         */
        X,
        /**
         * Orientation of the Y axis relative to gravity in g.
         * Values along the Y axis increase as the head tilts to the right.
         * Negative values indicate a tilt to the left.<br>
         */
        Y,
        /** Orientation of the Z axis relative to gravity in g.<br> */
        Z
    }

    public enum Magnetometer : int
    {
        X,
        Y,
        Z
    }

    public enum Battery : int
    {
        /** Charge percentage remaining of battery. */
        CHARGE_PERCENTAGE_REMAINING,
        /** Millivolts of battery from the view of the fuel gauge. */
        MILLIVOLTS,
        /** Temperature in degrees Celsius. */
        TEMPERATURE_CELSIUS,
        /** Average current in microamps. */
        AVERAGE_CURRENT,
        /** Remaining seconds until charge depleted (while discharging). */
        TIME_TO_EMPTY,
        /** Remaining seconds until fully charged (while charging). */
        TIME_TO_FULL,
        /** Full capacity of battery in mAh.   */
        BATTERY_CAPACITY,
        /** Remaining capacity of battery in mAh. */
        REMAINING_CAPACITY,
        /** Percentage battery age calculated from capacity. */
        BATTERY_AGE,
        /** Total number of charge/discharge cycles. */
        TOTAL_CYCLES
    }

    public enum Pressure : int
    {
        /** The raw pressure value returned by the pressure sensor in mBar */
        RAW,
        /**
         * The averaged pressure value in mBar based on the last 10 readings.  This
         * provides a smoother curve for the pressure values.
         */
        AVERAGED
    }

    public enum UltraViolet : int
    {
        UV_INDEX,
        UV_A,
        UV_B
    }

    public enum Ppg : int
    {
        /** Ambient, Green or IR-H16. */
        AMBIENT,
        /** IR. */
        IR,
        /** Red. */
        RED
    }

    public enum DrlRef : int
    {
        /** DRL sensor */
        DRL,
        /** REF sensor */
        REF
    }

    public enum Optics : int
    {
        /** 730nm left outer (8 and 16 channel modes) or 730nm left inner (4 channel mode) */
        OPTICS1,
        /** 730nm right outer (8 and 16 channel modes) or 730nm right inner (4 channel mode) */
        OPTICS2,
        /** 850nm left outer (8 and 16 channel modes) or 850nm left inner (4 channel mode) */
        OPTICS3,
        /** 850nm right outer (8 and 16 channel modes) or 850nm right inner (4 channel mode) */
        OPTICS4,
        /** 730nm left inner (8 and 16 channel modes) */
        OPTICS5,
        /** 730nm right inner (8 and 16 channel modes) */
        OPTICS6,
        /** 850nm left inner (8 and 16 channel modes) */
        OPTICS7,
        /** 850nm right inner (8 and 16 channel modes) */
        OPTICS8,
        /** Red left outer (16 channel mode)    */
        OPTICS9,
        /** Red right outer (16 channel mode) */
        OPTICS10,
        /** Ambient left outer (16 channel mode) */
        OPTICS11,
        /** Ambient right outer (16 channel mode) */
        OPTICS12,
        /** Red left inner (16 channel mode) */
        OPTICS13,
        /** Red right inner (16 channel mode) */
        OPTICS14,
        /** Ambient left inner (16 channel mode) */
        OPTICS15,
        /** Ambient right inner (16 channel mode) */
        OPTICS16
    }

    public enum MessageType : int
    {
        /** A message containing eeg data. */
        EEG,
        /** A message containing quantization data. */
        QUANTIZATION,
        /** A message containing accelerometer data. */
        ACCELEROMETER,
        /** A message containing battery data. */
        BATTERY,
        /** A message containing version data. */
        VERSION,
        /** A message containing configuration data. */
        CONFIGURATION,
        /** A message containing annotation data. */
        ANNOTATION,
        /** A message containing histogram data. */
        HISTOGRAM,
        /** A message containing algorithm data. */
        ALG_VALUE,
        /** A message containing dsp data. */
        DSP,
        /** A message containing device data. */
        COMPUTING_DEVICE,
        /** A message containing dropped eeg data. */
        EEG_DROPPED,
        /** A message containing dropped acc data. */
        ACC_DROPPED,
        /** A message containing data from the calm application. */
        CALM_APP,
        /** A message containing data from the calm algorithm. */
        CALM_ALG,
        /** A message containing muse element data. */
        MUSE_ELEMENTS,
        /** A message containing gyro data. */
        GYRO,
        /** A message containing artifact packet. */
        ARTIFACT,
        /** A message containing pressure data. */
        PRESSURE,
        /** A message containing temperature data. */
        TEMPERATURE,
        /** A message containing ultra violet data. */
        ULTRA_VIOLET,
        /** A message containing magnetometer data. */
        MAGNETOMETER,
        /** A message containing ppg data. */
        PPG,
        /** A message containing thermistor data. */
        THERMISTOR,
        /** A message containing optics data. */
        OPTICS,
        /** A message containing algorithm data. */
        ALGORITHM
    }

    public enum AnnotationFormat : int
    {
        /** The data is a string with no inherrent format. */
        PLAIN_STRING,
        /** The data is a string of JSON name, value pairs. */
        JSON,
        /** The data is formatted as OSC (open sound control) data. */
        OSC
    }

    public enum TimestampMode : int
    {
        /**
         * Legacy mode.
         *
         * Use the current time for everything except data packets. Use the data
         * packet's timestamp field for those.
         */
        LEGACY,
        /** Use the current time for timestamps. */
        CURRENT,
        /** Use set_timestamp for timestamps. */
        EXPLICIT
    }
}